using System;
using System.Collections.Generic;

namespace AccountMicroService.Model
{
    public partial class Financialo
    {
        public long Pk { get; set; }
        public DateTime? Cdate { get; set; }
        public string? Cuser { get; set; }
        public string? Uuser { get; set; }
        public string? Accountcode { get; set; }
        public string? Accountnumber { get; set; }
        public long? Accountpk { get; set; }
        public bool Closed { get; set; }
        public string Code { get; set; } = null!;
        public string Currencycode { get; set; } = null!;
        public long Currencypk { get; set; }
        public bool? Differed { get; set; }
        public string? Differedcondition { get; set; }
        public string? Extreference { get; set; }
        public decimal? Fxrate { get; set; }
        public string? Globalreference { get; set; }
        public decimal Grossamount { get; set; }
        public decimal Netamount { get; set; }
        public string? Opeinfo { get; set; }
        public string Operationtypecode { get; set; } = null!;
        public long Operationtypepk { get; set; }
        public string? Paymentmeanref { get; set; }
        public bool? Processed { get; set; }
        public string Reference { get; set; } = null!;
        public string? Relatedoperation { get; set; }
        public bool? Reversed { get; set; }
        public string? Reversedfinancialopecode { get; set; }
        public long? Reversedfinancialopepk { get; set; }
        public string Sign { get; set; } = null!;
        public decimal? Totalcomission { get; set; }
        public decimal? Totalfiscalretention { get; set; }
        public decimal? Totalvat { get; set; }
        public DateTime Tradedate { get; set; }
        public string Unitcode { get; set; } = null!;
        public long Unitpk { get; set; }
        public DateTime? Udate { get; set; }
        public int? Versionnum { get; set; }
        public string? Abstractopetype { get; set; }
        public bool? Cannegoce { get; set; }
        public decimal? Creditamount { get; set; }
        public decimal? Debitamount { get; set; }
        public string? Exempttype { get; set; }
        public bool? Filtrereport { get; set; }
        public decimal? Grossamountacccur { get; set; }
        public string? Lockoperationreference { get; set; }
        public decimal? Netamountacccur { get; set; }
        public string? Reservationreference { get; set; }
        public decimal? Totalcomissionacccur { get; set; }
        public decimal? Totalfracccur { get; set; }
        public decimal? Totalstamp { get; set; }
        public decimal? Totaltaf { get; set; }
        public decimal? Totalvatacccur { get; set; }
        public string? Comment { get; set; }
        public string? Description { get; set; }
        public bool? Force { get; set; }
        public DateTime? Forcedate { get; set; }
        public string? Forceuser { get; set; }

        public virtual Financialo? ReversedfinancialopepkNavigation { get; set; }
        public virtual Financialo? InverseReversedfinancialopepkNavigation { get; set; }
    }
}
