using FlaUI.Core.AutomationElements;
using PaintAutomation.Core.Extensions;
using PaintAutomation.UI.Dialogs;
using PaintAutomation.UI.Enums;

namespace PaintAutomation.UI.Components;

public class MenuBarComponent
{
	private readonly Window _mainWindow;

	public MenuBarComponent(Window mainWindow) => _mainWindow = mainWindow;

	private MenuItem FileRootMenu =>
		_mainWindow.FindFirstDescendantWait(cf => cf.ByName("File")).AsMenuItem();

	private Button UndoButton =>
		_mainWindow.FindFirstDescendantWait(cf => cf.ByAutomationId("Undo")).AsButton();

	private Button RedoButton =>
		_mainWindow.FindFirstDescendantWait(cf => cf.ByAutomationId("Redo")).AsButton();

	private MenuItem SaveButton =>
		_mainWindow.FindFirstDescendantWait(cf => cf.ByAutomationId("Save")).AsMenuItem();

	private Window InputWindow =>
		_mainWindow.FindFirstDescendantWait(cf => cf.ByClassName("InputSiteWindowClass")).AsWindow();

	private MenuItem GetFileSubItem(FileMenuItem item) =>
		_mainWindow.FindFirstDescendantWait(cf => cf.ByAutomationId(item.GetEnumDescription())).AsMenuItem();

	private MenuItem GetSaveAsSubItem(SaveAsSubItem subItem) =>
		_mainWindow.FindFirstDescendantWait(cf => cf.ByName(subItem.GetEnumDescription())).AsMenuItem();

	public void SaveAs(SaveAsSubItem subItem, string fullPath)
	{
		FileRootMenu.Click();
		GetFileSubItem(FileMenuItem.SaveAs).Click();
		GetSaveAsSubItem(subItem).Click();
		SaveFile(fullPath);
	}

	public void Save(string fullPath)
	{
		InputWindow.Click();
		SaveButton.Click();
		SaveFile(fullPath);
	}

	public void CreateNewFile()
	{
		FileRootMenu.Click();
		GetFileSubItem(FileMenuItem.New).Click();
	}

	public void Open(string fullPath)
	{
		FileRootMenu.Click();
		GetFileSubItem(FileMenuItem.Open).Invoke();
		OpenFile(fullPath);
	}

	public ImagePropertiesDialog OpenImageProperties()
	{
		FileRootMenu.Click();
		GetFileSubItem(FileMenuItem.ImageProperties).Click();
		return new(_mainWindow.WaitForModalWindow());
	}

	public void Undo() => UndoButton.Invoke();

	public void Redo() => RedoButton.Invoke();

	private void SaveFile(string fullPath) =>
		new SaveDialog(_mainWindow.WaitForModalWindow()).SaveFile(fullPath);

	private void OpenFile(string fullPath) =>
		new OpenDialog(_mainWindow.WaitForModalWindow()).OpenFile(fullPath);
}
