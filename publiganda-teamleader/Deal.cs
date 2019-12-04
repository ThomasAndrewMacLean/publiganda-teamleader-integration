using System;
using System.Collections.Generic;
using System.Text;

namespace publiganda_teamleader
{
    public class Deal
    {
        public int id { get; set; }
        public string title { get; set; }
        public string _for { get; set; }
        public int for_id { get; set; }
        public string customer_name { get; set; }
        public int quotation_nr { get; set; }
        public string total_price_excl_vat { get; set; }
        public int probability { get; set; }
        public int phase_id { get; set; }
        public int responsible_user_id { get; set; }
        public int entry_date { get; set; }
        public string entry_date_formatted { get; set; }
        public int latest_activity_date { get; set; }
        public string latest_activity_date_formatted { get; set; }
        public object close_date { get; set; }
        public string close_date_formatted { get; set; }
        public string date_lost { get; set; }
        public string date_lost_formatted { get; set; }
        public string reason_refused { get; set; }
        public int source_id { get; set; }
    }
}