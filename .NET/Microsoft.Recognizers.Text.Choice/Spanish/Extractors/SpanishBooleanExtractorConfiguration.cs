﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

using Microsoft.Recognizers.Definitions.Spanish;

namespace Microsoft.Recognizers.Text.Choice.Spanish
{
    public class SpanishBooleanExtractorConfiguration : IBooleanExtractorConfiguration
    {
        public static readonly Regex TrueRegex = 
            new Regex(ChoiceDefinitions.TrueRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex FalseRegex = 
            new Regex(ChoiceDefinitions.FalseRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex TokenRegex = 
            new Regex(ChoiceDefinitions.TokenizerRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly IDictionary<Regex, string> MapRegexes =  new Dictionary<Regex, string>()
        {
            {TrueRegex, Constants.SYS_BOOLEAN_TRUE },
            {FalseRegex, Constants.SYS_BOOLEAN_FALSE }
        };

        public SpanishBooleanExtractorConfiguration(bool onlyTopMatch = true)
        {
            this.OnlyTopMatch = onlyTopMatch;
        }

        Regex IBooleanExtractorConfiguration.TrueRegex => TrueRegex;

        Regex IBooleanExtractorConfiguration.FalseRegex => FalseRegex;

        IDictionary<Regex, string> IChoiceExtractorConfiguration.MapRegexes => MapRegexes;

        Regex IChoiceExtractorConfiguration.TokenRegex => TokenRegex;

        public bool AllowPartialMatch => false;

        public int MaxDistance => 2;

        public bool OnlyTopMatch { get; }
    }
}