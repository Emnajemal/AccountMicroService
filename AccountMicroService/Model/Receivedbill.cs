using System;
using System.Collections.Generic;

namespace AccountMicroService.Model
{
    public partial class Receivedbill
    {
        public long Pk { get; set; }
        public DateTime? Cdate { get; set; }
        public string? Cuser { get; set; }
        public string? Uuser { get; set; }
        public bool? Accphysique { get; set; }
        public string? Acceptationcode { get; set; }
        public string? Accountcontractcode { get; set; }
        public long? Accountcontractpk { get; set; }
        public bool? Autoprocess { get; set; }
        public string? Avalrib { get; set; }
        public string? Bankcode { get; set; }
        public long? Bankpk { get; set; }
        public bool? Bap { get; set; }
        public string? Beneficiaryname { get; set; }
        public string Beneficiaryrib { get; set; } = null!;
        public string? Beneficiaryref { get; set; }
        public decimal? Billamount { get; set; }
        public long? Billimagepk { get; set; }
        public long? Billimageversopk { get; set; }
        public string Billreference { get; set; } = null!;
        public long? Clearingpk { get; set; }
        public string? Codelabel { get; set; }
        public string? Codeordrepay { get; set; }
        public DateTime Creationdatebill { get; set; }
        public string? Creationlocation { get; set; }
        public string Currencycode { get; set; } = null!;
        public long Currencypk { get; set; }
        public DateTime? Datecompensationinitiale { get; set; }
        public DateTime? Dealingroomdate { get; set; }
        public decimal? Dealingroomgrossamount { get; set; }
        public decimal? Dealingroomnetamount { get; set; }
        public decimal? Dealingroomrate { get; set; }
        public string? Dealingroomreference { get; set; }
        public decimal? Dealingroomtotalcommission { get; set; }
        public decimal? Dealingroomtotalvat { get; set; }
        public string? Depositname { get; set; }
        public bool Draft { get; set; }
        public string? Draweereference { get; set; }
        public string? Endoseravalcode { get; set; }
        public string? Eventtypecode { get; set; }
        public long? Eventtypepk { get; set; }
        public string? Exempttype { get; set; }
        public string? Extreference { get; set; }
        public DateTime Fallingduedate { get; set; }
        public bool? Force { get; set; }
        public string? Freetext { get; set; }
        public decimal? Fxgrossamount { get; set; }
        public decimal? Fxnetamount { get; set; }
        public decimal? Fxrate { get; set; }
        public decimal? Fxtotalcommission { get; set; }
        public decimal? Fxtotalvat { get; set; }
        public decimal? Grossamount { get; set; }
        public bool? Hascomplementaryrecords { get; set; }
        public DateTime? Initialfallingduedate { get; set; }
        public string? Initialpayerrib { get; set; }
        public string? Instrumentcode { get; set; }
        public decimal Interestamount { get; set; }
        public bool? Isdeal { get; set; }
        public bool? Issuedinlocal { get; set; }
        public string? Mandatorycodes { get; set; }
        public string? Naturebenef { get; set; }
        public bool? Negociateexchange { get; set; }
        public decimal? Netamount { get; set; }
        public string? Nrem { get; set; }
        public string? Ntrans { get; set; }
        public string? Operationtypecode { get; set; }
        public long? Operationtypepk { get; set; }
        public string? Papercode { get; set; }
        public string? Payername { get; set; }
        public string? Payerref { get; set; }
        public string Payerrib { get; set; } = null!;
        public decimal Protestfees { get; set; }
        public string Receivedbilllcstatus { get; set; } = null!;
        public DateTime? Receivedvaluedate { get; set; }
        public string? Refcommercialpayer { get; set; }
        public string? Reference { get; set; }
        public string? Referencerio { get; set; }
        public string? Rejectcodereasons { get; set; }
        public DateTime? Rejectdate { get; set; }
        public string? Reversalreason { get; set; }
        public string? Riskcode { get; set; }
        public long? Signatureimagepk { get; set; }
        public string? Situationbenef { get; set; }
        public DateTime? Spotdate { get; set; }
        public decimal? Totalcommission { get; set; }
        public decimal? Totalstamp { get; set; }
        public decimal? Totaltaf { get; set; }
        public decimal? Totalvat { get; set; }
        public DateTime? Tradedate { get; set; }
        public DateTime? Transitiondate { get; set; }
        public string? Unitcode { get; set; }
        public DateTime? Udate { get; set; }
        public string? Validationprocessname { get; set; }
        public string? Validationstepname { get; set; }
        public int? Versionnum { get; set; }
        public bool? Vfcheck { get; set; }
        public bool? Withaval { get; set; }
        public bool? Withoutimage { get; set; }
        public string? Emettingunit { get; set; }
        public string? Affecteduser { get; set; }
        public DateTime? Affectiondate { get; set; }
        public DateTime? Validationdate { get; set; }
        public string? Validationuser { get; set; }
        public bool? Manualclearing { get; set; }
        public bool? Restournecommission { get; set; }
        public bool? Provisionrejectioncancelled { get; set; }
        public string? Referencettn { get; set; }
        public long? Rcppk { get; set; }

        public virtual Accountcontract? AccountcontractpkNavigation { get; set; }
    }
}
