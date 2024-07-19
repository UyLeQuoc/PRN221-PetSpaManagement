﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ViewModels.PaymentDTOs
{
    public class VnpayOrderInfo
    {
        public int AppointmentId { get; set; }
        public decimal Amount { get; set; }
        public int? PaymentId { get; set; }
    }
}