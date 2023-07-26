using System;
using System.Collections.Generic;

namespace AccountMicroService.Model
{
    public partial class Accmovement
    {
        public Accmovement()
        {
            InverseReversedpkNavigation = new HashSet<Accmovement>();
        }

        public long Pk { get; set; }
        public DateTime? Cdate { get; set; }
        public string? Cuser { get; set; }
        public string? Uuser { get; set; }
        public string Accountcode { get; set; } = null!;
        public long Accountpk { get; set; }
        public decimal Amount { get; set; }
        public decimal? Amountacccur { get; set; }
        public DateTime Businessdate { get; set; }
        public string Currencycode { get; set; } = null!;
        public long Currencypk { get; set; }
        public long? Delay { get; set; }
        public string? Description { get; set; }
        public string? Feetypecode { get; set; }
        public long? Feetypepk { get; set; }
        public string? Finoperationcode { get; set; }
        public long? Finoperationpk { get; set; }
        public decimal? Fiscalretention { get; set; }
        public decimal? Fracccur { get; set; }
        public decimal? Fxrate { get; set; }
        public decimal Grossamount { get; set; }
        public decimal Grossamountacccur { get; set; }
        public bool Includedinmvtcomm { get; set; }
        public string? Internalvaldatedelay { get; set; }
        public bool? Isagios { get; set; }
        public bool Isreversed { get; set; }
        public bool Isreversing { get; set; }
        public string? Lockreference { get; set; }
        public bool? Locked { get; set; }
        public string Operationtypecode { get; set; } = null!;
        public long Operationtypepk { get; set; }
        public DateTime? Receivedvaluedate { get; set; }
        public decimal? Reservedamount { get; set; }
        public long? Reversedpk { get; set; }
        public string Sign { get; set; } = null!;
        public DateTime? Tradedate { get; set; }
        public DateTime? Treasurydate { get; set; }
        public string? Typemvt { get; set; }
        public DateTime? Udate { get; set; }
        public DateTime? Valuedate { get; set; }
        public decimal? Vat { get; set; }
        public decimal? Vatacccur { get; set; }
        public int? Versionnum { get; set; }
        public string? Accountnature { get; set; }
        public string? Bpnature { get; set; }
        public string? Branchenumber { get; set; }
        public string? Chequenumber { get; set; }
        public string? Clientreference { get; set; }
        public string? Currencynature { get; set; }
        public string? Intermediaryauthorized { get; set; }
        public string? Loanreference { get; set; }
        public string? Nametowards { get; set; }
        public string? Newoperationcode { get; set; }
        public string? Opecodeident { get; set; }
        public DateTime? Opedateident { get; set; }
        public string? Openumident { get; set; }
        public string? Operef { get; set; }
        public string? Operationmotif { get; set; }
        public string? Operationnumber { get; set; }
        public string? Ribtowards { get; set; }
        public string? Sbereference { get; set; }
        public string? Unitcode { get; set; }
        public string? Accountnumber { get; set; }
        public string? Operationdetailbp { get; set; }
        public long? Orderinsert { get; set; }
        public decimal? Commission { get; set; }
        public decimal? Affranchissement { get; set; }
        public DateTime? Datedeclaration { get; set; }
        public string? Emetteur { get; set; }
        public decimal? Montantdeclaration { get; set; }
        public string? Nationaliteemetteur { get; set; }
        public int? Naturedocument { get; set; }
        public string? Numdeclaration { get; set; }
        public string? Numpasseport { get; set; }
        public string? Reliquat { get; set; }
        public string? Countrybp { get; set; }
        public decimal? Creditmnt { get; set; }
        public decimal? Debitmnt { get; set; }
        public decimal? Frmaincur { get; set; }
        public decimal? Grossamountmaincur { get; set; }
        public bool? Iscommission { get; set; }
        public bool? Isprinted { get; set; }
        public decimal? Totalstamp { get; set; }
        public decimal? Totaltaf { get; set; }
        public decimal? Vatmaincur { get; set; }
        public bool? Senddealroom { get; set; }
        public DateTime? Basisvaluedate { get; set; }
        public string? Typevaluedate { get; set; }

        public virtual Accmovement? ReversedpkNavigation { get; set; }
        public virtual ICollection<Accmovement> InverseReversedpkNavigation { get; set; }
    }
}
