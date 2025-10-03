using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Tools;

namespace PaintAutomation.Core.Extensions;

public static class WindowExtensions
{
	public static void WaitUntilClosed(this Window window, TimeSpan? timeout = null) =>
		Retry.WhileTrue(() => window.IsAvailable, timeout ?? TimeSpan.FromSeconds(5));

	public static Window WaitForModalWindow(this Window parent, TimeSpan? timeout = null)
	{
		var result = Retry.WhileNull(() => parent.ModalWindows.FirstOrDefault(), timeout ?? TimeSpan.FromSeconds(5));

		if (!result.Success || result.Result == null)
			throw new TimeoutException("Modal window was not found within the timeout.");

		return result.Result;
	}

	public static AutomationElement FindFirstDescendantWait(
		this Window window, Func<ConditionFactory, ConditionBase> by, TimeSpan? timeout = null)
	{
		var result = Retry.WhileNull(() => window.FindFirstDescendant(by), timeout ?? TimeSpan.FromSeconds(5));

		if (!result.Success || result.Result == null)
			throw new TimeoutException($"Element '{by}' was not found within timeout.");

		return result.Result;
	}
}
