using HackathonVinci2.Models;
using HackathonVinci2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackathonVinci2.Fassade
{
    public static class Methods
    {
        public static ResultModel fillmodel(InputModel input)
        {
            ResultModel result = new ResultModel();
            var dbcontext = new EnergyEntities();
            
            var coal = dbcontext.DATA.Where(x => x.ASSET_ID == "1").OrderByDescending(x => x.DATE).First();
            var solar = dbcontext.DATA.Where(x => x.ASSET_ID == "3").OrderByDescending(x => x.DATE).First();
            var wind = dbcontext.DATA.Where(x => x.ASSET_ID == "2").OrderByDescending(x => x.DATE).First();
            result.Month = input.Duration;
            var allHours = coal.OPERATING_HOURS * input.CoalSiteAmount + solar.OPERATING_HOURS * input.SolarSiteAmount + wind.OPERATING_HOURS * input.WindSiteAmount;
            var PriceList = dbcontext.PRICES.Take(input.Duration).ToList();
            
            foreach(var item in PriceList)
            {
                result.Ertrag += (decimal)(item.PRICE * allHours);
            }
            result.TableList.Add(new rowElement() { Name = "CO²", Coal = (decimal)coal.C02_COSTS * input.Duration, Solar = (decimal)solar.C02_COSTS * input.Duration, Wind = (decimal)wind.C02_COSTS * input.Duration });
            result.TableList.Add(new rowElement() { Name = "Fuel cost", Coal = (decimal)coal.FUEL_COSTS * input.Duration, Solar = (decimal)solar.FUEL_COSTS * input.Duration, Wind = (decimal)wind.FUEL_COSTS * input.Duration });
            result.TableList.Add(new rowElement() { Name = "Cost of capital", Coal = (decimal)coal.CAPITAL_CHARGES * input.Duration, Solar = (decimal)solar.CAPITAL_CHARGES * input.Duration, Wind = (decimal)wind.CAPITAL_CHARGES * input.Duration });
            result.TableList.Add(new rowElement() { Name = "Operating hours", Coal = (decimal)coal.OPERATING_HOURS * input.Duration, Solar = (decimal)solar.OPERATING_HOURS * input.Duration, Wind = (decimal)wind.OPERATING_HOURS * input.Duration });
            result.ViewErtrag = result.Ertrag.ToString("#.##");

            return result;

        }
    }
}