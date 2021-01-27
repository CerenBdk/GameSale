using System;
using GameSale.Entities;
using GameSale.IManagers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSale.IManagers
{
    public class CampaignManager:ICampaignManager
    {
        public static List<Campaign> campaignList = new List<Campaign>();
        
        public void Add(Campaign campaign)
        {
            if (campaignList.Any(x => x.Title == campaign.Title & x.StartedAt == campaign.StartedAt ))
            {
                Console.WriteLine("{0} has already been added.", campaign.Title);
            }
            else
            {
                campaign.ID = campaignList.Count + 1;
                campaignList.Add(campaign);
                Console.WriteLine("{0} has been added.", campaign.Title);
            } 
        }

        public void Update(Campaign campaign, Campaign campaign1)
        {
            if (campaignList.Any(x => x.ID == campaign.ID))
            {
                campaign.Title = campaign1.Title;
                campaign.StartedAt = campaign1.StartedAt;
                campaign.CompletedAt = campaign1.CompletedAt;
                campaign.DiscountRate = campaign1.DiscountRate;
                Console.WriteLine("{0} has been updated.\n", campaign.Title);
            }
            else
            {
                Console.WriteLine("{0} is not found.", campaign.Title);
            }
        }

        public void Delete(int ID)
        {
            if (ID != 0)
            {
                if (campaignList.Any(x => x.ID == ID))
                {
                    var tempCampaign = campaignList.FirstOrDefault(x => x.ID == ID);
                    campaignList.Remove(tempCampaign);
                    Console.WriteLine("{0} has been deleted.", tempCampaign.Title);
                }
                else
                {
                    Console.WriteLine("{0} is not found.", ID);
                }
            }
            else
            {
                Console.WriteLine("Undefined ID number");
            }
        }

        public void WriteAll()
        {
            if (campaignList.Count > 0)
            {
                int count = 1;
                Console.WriteLine("---------- Campaign List ----------");
                foreach (var campaign in campaignList)
                {
                    Console.WriteLine("{0})ID: {1}\n  Title: {2}\n  Started At: {3}\n  Remain Days: {4}\n  Discount Rate: {5}\n", count, campaign.ID, campaign.Title, campaign.StartedAt, (campaign.CompletedAt - DateTime.Now).Days, campaign.DiscountRate);
                    count++;
                }
            }
            else
            {
                Console.WriteLine("No campaign has been added yet.");
            }
        }

        public Campaign FindByID(int ID)
        {
            Campaign tempCampaign = new Campaign();

            if (campaignList.Any(x => x.ID == ID))
            {
                tempCampaign = campaignList.FirstOrDefault(x => x.ID == ID);
            }
            else
            {
                Console.WriteLine("{0} is not found.", ID);
            }
            
            return tempCampaign;
        }

        public List<Campaign> GetList()
        {
            return campaignList;
        }
    }
}
