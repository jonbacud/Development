namespace Web.Dashboard.Shared
{
    public static class Transaction
    {
        public enum TransactionMode
        {
            NewEntry = 1,
            UpdateEntry = 0,
            ViewDetail = 2
        }

        public enum TransactionType
        {
          RIS, // Requisition
          ISS, // Issuance
          RCV,  //Receiving
          RRCV, // Return Receiving
          RISS, // Return Issuance
          DON,  // Donation
          CON   // Consignment
        }

        public enum TransactionStatus
        {
            Submitted, // Requisittion Status
            Partial, // Receiving status
            Completed, // Receiving status
            Posted // Receiving
        }
    }
}