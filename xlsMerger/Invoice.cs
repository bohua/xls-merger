using System;
using System.Collections.Generic;
using System.Text;

namespace XlsMerger
{
	class Invoice : IEquatable<Invoice>
	{
		public string invoiceNumber { get; set; }
		public string filePath { get; set; }

		public Invoice( string number, string path) {
			this.invoiceNumber = number;
			this.filePath = path;
		}

		public bool Equals(Invoice other) {
			if (this.invoiceNumber == other.invoiceNumber && this.filePath == other.filePath) {
				return true;
			}
			return false;
		}
	}
}
