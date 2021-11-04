using System;
using System.Collections.Generic;

namespace ApplicationEntities
{
    [Serializable]
    public abstract class TradingPartner
    {
        public int TradingPartnerId { get; set; }
        public string TradingPartnerName { get; set; }
        public string City { get; set; }

        public virtual List<string> Validate()
        {
            List<string> errors = new List<string>();

            //Validation for TradingPartnerId
            if (TradingPartnerId <= 0)
            {
                errors.Add("Trading Partner Id should be non-negative and greater than zero");
            }

            //Validation for TradingPartnerName

            if (string.IsNullOrEmpty(TradingPartnerName) || TradingPartnerName.Length < 5)
            {

                errors.Add("Trading Partner Name should be mandatory and greater than four chars");
            }
            //Validation for City

            if (string.IsNullOrEmpty(City) || City.Length < 3)
            {

                errors.Add("City is mandatory and should be greater than 2 chars");
            }
            return errors;
        }

        public abstract void SaveToFile(string filepath);

    }

}
