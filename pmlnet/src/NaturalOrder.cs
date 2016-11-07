using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aveva.PDMS.PMLNet;

namespace Xpml
{
	[PMLNetCallable()]
	public class NaturalOrder
	{
	    [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
	    public static extern int StrCmpLogicalW(string s1, string s2);

	    [PMLNetCallable()]
		public NaturalOrder()
		{
		}
        [PMLNetCallable()]
        public event PMLNetDelegate.PMLNetEventHandler PMLNetExampleEvent;
        [PMLNetCallable()]
        public void RaiseExampleEvent()
        {
            ArrayList args = new ArrayList();
            args.Add("ExampleEvent");
            if (PMLNetExampleEvent != null)
                PMLNetExampleEvent(args);
        }
        [PMLNetCallable()]
        public void Assign(NaturalOrder that)
        {
        }
        [PMLNetCallable()]
        public Hashtable SortedIndices(Hashtable items)
        {
        	Hashtable ret = new Hashtable();
        	
        	List<KeyValuePair<double,string>> list = new List<KeyValuePair<double, string>>(ret.Count);
        	foreach(DictionaryEntry kv in items) {
        		var kvp = new KeyValuePair<double,string>(Convert.ToDouble(kv.Key), kv.Value.ToString());
        		list.Add(kvp);
        	}
        	
        	list.Sort((kv1, kv2) => StrCmpLogicalW(kv1.Value, kv2.Value));
        	
        	double d;
        	for(int i=0; i<list.Count; i++) {
        		d = i+1;
        		ret.Add(d, list[i].Key);
        	}
        	
        	return ret;
        }
	}
}
