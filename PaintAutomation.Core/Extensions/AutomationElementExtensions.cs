using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;

namespace PaintAutomation.Core.Extensions;

public static class AutomationElementExtensions
{
	public static AutomationElement? WaitUntilAvailable(this AutomationElement element, TimeSpan? timeout = null)
	{
		var result = Retry.WhileNull(() => element, timeout ?? TimeSpan.FromSeconds(5));

		if (!result.Success)
			throw new TimeoutException("Element was not available in time.");

		return result.Result;
	}

	public static void SafeClick(this AutomationElement element)
	{
		element.WaitUntilAvailable();
		element.FocusNative();
		element.AsButton().Click();
	}
}
