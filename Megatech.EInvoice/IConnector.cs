using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megatech.EInvoice
{
    public interface IConnector
    {
        void SendInvoice(InvoiceData invoiceData);
    }
}
