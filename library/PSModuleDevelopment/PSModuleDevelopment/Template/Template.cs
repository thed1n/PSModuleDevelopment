﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSModuleDevelopment.Template
{
    /// <summary>
    /// The master class containing a template
    /// </summary>
    [Serializable]
    public class Template
    {
        /// <summary>
        /// The name of the template
        /// </summary>
        public string Name;

        /// <summary>
        /// What kind of template is this?
        /// </summary>
        public TemplateType Type;

        /// <summary>
        /// What version is the template
        /// </summary>
        public Version Version;

        /// <summary>
        /// Text describing the template
        /// </summary>
        public string Description;

        /// <summary>
        /// Author of the template
        /// </summary>
        public string Author;

        /// <summary>
        /// When was the template originally created?
        /// </summary>
        public DateTime CreatedOn;

        /// <summary>
        /// List of tags that have been assigned to the template
        /// </summary>
        public List<string> Tags = new List<string>();

        /// <summary>
        /// List of parameters the template accepts
        /// </summary>
        public List<string> Parameters = new List<string>();

        /// <summary>
        /// List of scripts that will be invoked on initialization
        /// </summary>
        public Dictionary<string, ParameterScript> Scripts = new Dictionary<string, ParameterScript>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// List of generation 2 parameters to include
        /// </summary>
        public Dictionary<string, Parameter.ParameterBase> Parameters2 = new Dictionary<string, Parameter.ParameterBase>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Items in the root directory of the template (which may contain children themselves).
        /// </summary>
        public List<TemplateItemBase> Children = new List<TemplateItemBase>();

        /// <summary>
        /// What design generation is the template?
        /// </summary>
        public int Generation = 1;

        /// <summary>
        /// Returns the template digest used as index file.
        /// </summary>
        /// <returns>A TemplateInfo object describing this template.</returns>
        public TemplateInfo ToTemplateInfo()
        {
            List<string> parameters = new List<string>(Parameters);
            if (Parameters2.Count > 0)
                parameters.AddRange(Parameters2.Values.Where(o => o.GetType().Name == "ParameterPrompt").Select(o => o.Name));

            TemplateInfo info = new TemplateInfo();
            info.Author = Author;
            info.CreatedOn = CreatedOn;
            info.Description = Description;
            info.Name = Name;
            info.Parameters = parameters;
            info.Tags = Tags;
            info.Type = Type;
            info.Version = Version;
            info.Generation = Generation;

            return info;
        }
    }
}
