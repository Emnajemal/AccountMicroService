using System;
using System.Collections.Generic;

namespace AccountMicroService.Model
{
    public partial class Recvplv
    {
        public long Pk { get; set; }
        public DateTime? Cdate { get; set; }
        public string? Cuser { get; set; }
        public string? Uuser { get; set; }
        public string? Accountcontractcode { get; set; }
        public long? Accountcontractpk { get; set; }
        public string? Accountnumber { get; set; }
        public string? Accountrib { get; set; }
        public bool? Autoprocess { get; set; }
        public string? Bankcode { get; set; }
        public long? Bankpk { get; set; }
        public string? Beneficiaryname { get; set; }
        public string? Beneficiaryrib { get; set; }
        public string? Clearinglock { get; set; }
        public long? Clearingpk { get; set; }
        public string? Clientidentifier { get; set; }
        public string? Codeemetteur { get; set; }
        public string? Codelabel { get; set; }
        public string Currencycode { get; set; } = null!;
        public long Currencypk { get; set; }
        public DateTime? Dealingroomdate { get; set; }
        public decimal? Dealingroomgrossamount { get; set; }
        public decimal? Dealingroomnetamount { get; set; }
        public decimal? Dealingroomrate { get; set; }
        public string? Dealingroomreference { get; set; }
        public decimal? Dealingroomtotalcommission { get; set; }
        public decimal? Dealingroomtotalvat { get; set; }
        public string? Depositname { get; set; }
        public bool Draft { get; set; }
        public string? Eventtypecode { get; set; }
        public long? Eventtypepk { get; set; }
        public string? Exempttype { get; set; }
        public string? Extreference { get; set; }
        public bool? Force { get; set; }
        public string? Freetext { get; set; }
        public bool? Fromcentralservice { get; set; }
        public bool? Fromclearing { get; set; }
        public bool? Fromsbe { get; set; }
        public decimal? Fxgrossamount { get; set; }
        public decimal? Fxnetamount { get; set; }
        public decimal? Fxrate { get; set; }
        public decimal? Fxtotalcommission { get; set; }
        public decimal? Fxtotalvat { get; set; }
        public decimal? Grossamount { get; set; }
        public bool? Isdeal { get; set; }
        public bool? Locked { get; set; }
        public string? Mandatorycodes { get; set; }
        public DateTime? Maturitydate { get; set; }
        public bool? Negociateexchange { get; set; }
        public decimal? Netamount { get; set; }
        public string? Nrem { get; set; }
        public string? Ntrans { get; set; }
        public string? Numtranche { get; set; }
        public string? Objet { get; set; }
        public string? Opetypeintracible { get; set; }
        public string? Opetypeintrasource { get; set; }
        public string Operationtypecode { get; set; } = null!;
        public long Operationtypepk { get; set; }
        public string? Paymentdocnum { get; set; }
        public string? Paymentdocreference { get; set; }
        public string? Plvauthcode { get; set; }
        public long? Plvauthpk { get; set; }
        public DateTime? Receivedvaluedate { get; set; }
        public DateTime Receptiondate { get; set; }
        public string? Reference { get; set; }
        public string? Referencerio { get; set; }
        public string? Rejectcodereasons { get; set; }
        public DateTime? Rejectdate { get; set; }
        public string? Reversalreason { get; set; }
        public DateTime? Spotdate { get; set; }
        public string Status { get; set; } = null!;
        public decimal? Totalcommission { get; set; }
        public decimal? Totalstamp { get; set; }
        public decimal? Totaltaf { get; set; }
        public decimal? Totalvat { get; set; }
        public DateTime? Tradedate { get; set; }
        public DateTime? Transitiondate { get; set; }
        public string? Unitcode { get; set; }
        public DateTime? Udate { get; set; }
        public bool? Validatecomptereg { get; set; }
        public string? Validationprocessname { get; set; }
        public string? Validationstepname { get; set; }
        public long? Validationspk { get; set; }
        public int? Versionnum { get; set; }
        public DateTime? Clearingdate { get; set; }
        public string? Affecteduser { get; set; }
        public DateTime? Affectiondate { get; set; }
        public DateTime? Validationdate { get; set; }
        public string? Validationuser { get; set; }
        public bool? Restournecommission { get; set; }
        public bool? Fromcompense { get; set; }
        public string? Relatedprelevementpk { get; set; }
        public long? Compensecentralpk { get; set; }
        public long? Rcppk { get; set; }

        public virtual Accountcontract? AccountcontractpkNavigation { get; set; }
    }
}
