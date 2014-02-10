using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XlsMerger
{
	public interface cInfDjList
	{
		cInfDj getSheetAt(int index);
		int getSize();
		//public List<cInfDj> getSheetList();
	}

	public interface cInfDj
	{
		void setInvNum(string val);
		string getSheetId();
		string getDate();
		string getInvNum();
	}
}
