﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Binding.Interfaces;

namespace Binding
{
    /// <summary>
    /// Managers a collection of binding sequences. Represents the various binding
    /// methods found on page. 
    /// </summary>
    public class BindingSequenceManager
    {
        private Dictionary<string, BindingSequnce> sequences;
        public Dictionary<string, BindingSequnce> Sequences
        {
            get
            {
                if (sequences == null)
                    sequences = new Dictionary<string, BindingSequnce>();

                return sequences;
            }
        }
    }

    /// <summary>
    /// An object representation of the binding instructions that occur as part of a control
    /// properties bind method (as generated by the asp.net page parser)
    /// </summary>
    public class BindingSequnce
    {
        public List<IBindingInstruction> Instructions { get; set; }
        public int CurrentIndex { get; private set; }

        private IBindingInstruction currentInstruction;
        public IBindingInstruction CurrentInstruction
        {
            get
            {
                if (this.Instructions != null)
                {
                    currentInstruction = this.Instructions[this.CurrentIndex];
                }

                return currentInstruction;
            }
        }

        public void MoveNext()
        {

            //This ensures we do not get an index out of range as a result of binding within a template items controls
            if ((CurrentIndex + 1) < Instructions.Count)
                CurrentIndex++;
            else
                CurrentIndex = 0;
        }
    }

   
}