﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationMvc.Services.Payment
{
    [Table("Payment")]
    public class VnPaymentResponse
    {
        [Key]
        [BindProperty(Name = "vnp_Amount")]
        public int Amount { get; set; }
        [BindProperty(Name = "vnp_BankCode")]
        public string BankCode { get; set; } = null!;
        [BindProperty(Name = "vnp_BankTranNo")]
        public string BankTranNo { get; set; } = null!;
        [BindProperty(Name = "vnp_CardType")]
        public string CardType { get; set; } = null!;
        [BindProperty(Name = "vnp_OrderInfo")]
        public string OrderInfo { get; set; } = null!;
        [BindProperty(Name = "vnp_PayDate")]
        public string PayDate { get; set; } = null!;
        [BindProperty(Name = "vnp_ResponseCode")]
        public string ResponseCode { get; set; } = null!;
        // [BindProperty(Name = "vnp_TmnCode")]
        // public string TmnCode { get; set; } = null!;
        [BindProperty(Name = "vnp_TransactionNo")]
        public string TransactionNo { get; set; } = null!;
        [BindProperty(Name = "vnp_TransactionStatus")]
        public string TransactionStatus { get; set; } = null!;
        [BindProperty(Name = "vnp_TxnRef")]
        public string TxnRef { get; set; } = null!;
        // [BindProperty(Name = "vnp_SecureHash")]
        // public string SecureHash { get; set; } = null!;
    }
}
