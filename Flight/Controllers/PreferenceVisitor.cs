using System;
using Antlr4.Runtime;
using Flight.Antlr;

using System.Collections.Generic;

namespace Flight.Controllers
{

    public class PreferenceVisitor : PreferenceLanguageBaseVisitor<Object>
    {
        public List<PreferenceParsed> Preferences = new List<PreferenceParsed>();

        public override object VisitPreference( PreferenceLanguageParser.PreferenceContext context)
        {   

            PreferenceParsed singlePreference = new PreferenceParsed() { PreferenceParsedText = context.GetText() };
            Preferences.Add(singlePreference);

            return base.VisitPreference(context);

        }
       
    }
}
