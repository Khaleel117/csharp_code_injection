using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data;

namespace dotnet_calculator.Pages
{
    public class IndexModel : PageModel
    {
        public string Screen { get; set; } = "0";

        public void OnGet()
        {
        }

public void OnPost(string button)
{
    Screen = TempData["Screen"] as string ?? "0";

    switch (button)
    {
        case "CE":
            Screen = "0";
            break;
        case "=":
            try
            {
                Screen = Evaluate(Screen).ToString();
            }
            catch
            {
                Screen = "Error";
            }
            break;
        default:
            if (Screen == "0" && button != "0")
            {
                Screen = button;
            }
            else
            {
                Screen += button;
            }
            break;
    }

    TempData["Screen"] = Screen;
}

        private static double Evaluate(string expression)
        {
            var dataTable = new DataTable();
            return (double)Convert.ChangeType(dataTable.Compute(expression, null), typeof(double));
        }
    }
}