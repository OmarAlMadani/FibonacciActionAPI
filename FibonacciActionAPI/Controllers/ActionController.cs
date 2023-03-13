using FibonacciActionAPI;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ActionController : ControllerBase
{
    private ActionInfo GetActionWithMaxAvgPrice()
    {
        var actions = new[] { "AMZN", "CACC", "EQIX", "GOOG", "ORLY", "ULTA" };
        var prices = new[,]
        {
        { 12.81, 11.09, 12.11, 10.93, 9.83, 8.14 },
        { 10.34, 10.56, 10.14, 12.17, 13.1, 11.22 },
        { 11.53, 10.67, 10.42, 11.88, 11.77, 10.21 }
    };

        var actionPrices = actions
            .Select((action, i) => new { Action = action, Prices = prices.Cast<double>().Where((price, j) => j % prices.GetLength(1) == i) });

        var maxAvgPrice = double.MinValue;
        string maxActionName = string.Empty;

        foreach (var actionPricesPair in actionPrices)
        {
            var avgPrice = actionPricesPair.Prices.Any() ? actionPricesPair.Prices.Average() : 0;

            if (avgPrice > maxAvgPrice)
            {
                maxAvgPrice = avgPrice;
                maxActionName = actionPricesPair.Action;
            }
        }
        var roundedAvgPrice = Math.Round(maxAvgPrice, 2, MidpointRounding.AwayFromZero);
        return new ActionInfo { Name = maxActionName, AvgPrice = roundedAvgPrice };
    }



    [HttpGet]
    public ActionResult<ActionInfo> Get()
    {
        var actionInfo = GetActionWithMaxAvgPrice();
        
        return new ActionInfo { Name = actionInfo.Name, AvgPrice = actionInfo.AvgPrice };
    }

}
