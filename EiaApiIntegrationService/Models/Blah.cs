using System;
using System.Collections.Generic;
using System.Text;

namespace EiaApiIntegrationService.Models
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class eia_api
    {

        private eia_apiRequest requestField;

        private eia_apiSeries seriesField;

        /// <remarks/>
        public eia_apiRequest request
        {
            get
            {
                return this.requestField;
            }
            set
            {
                this.requestField = value;
            }
        }

        /// <remarks/>
        public eia_apiSeries series
        {
            get
            {
                return this.seriesField;
            }
            set
            {
                this.seriesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eia_apiRequest
    {

        private string commandField;

        private string series_idField;

        /// <remarks/>
        public string command
        {
            get
            {
                return this.commandField;
            }
            set
            {
                this.commandField = value;
            }
        }

        /// <remarks/>
        public string series_id
        {
            get
            {
                return this.series_idField;
            }
            set
            {
                this.series_idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eia_apiSeries
    {

        private eia_apiSeriesRow rowField;

        /// <remarks/>
        public eia_apiSeriesRow row
        {
            get
            {
                return this.rowField;
            }
            set
            {
                this.rowField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eia_apiSeriesRow
    {

        private string series_idField;

        private string nameField;

        private string unitsField;

        private string fField;

        private string unitsshortField;

        private string descriptionField;

        private string copyrightField;

        private string sourceField;

        private string iso3166Field;

        private string geographyField;

        private uint startField;

        private uint endField;

        private string updatedField;

        private eia_apiSeriesRowRow[] dataField;

        /// <remarks/>
        public string series_id
        {
            get
            {
                return this.series_idField;
            }
            set
            {
                this.series_idField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        public string f
        {
            get
            {
                return this.fField;
            }
            set
            {
                this.fField = value;
            }
        }

        /// <remarks/>
        public string unitsshort
        {
            get
            {
                return this.unitsshortField;
            }
            set
            {
                this.unitsshortField = value;
            }
        }

        /// <remarks/>
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public string copyright
        {
            get
            {
                return this.copyrightField;
            }
            set
            {
                this.copyrightField = value;
            }
        }

        /// <remarks/>
        public string source
        {
            get
            {
                return this.sourceField;
            }
            set
            {
                this.sourceField = value;
            }
        }

        /// <remarks/>
        public string iso3166
        {
            get
            {
                return this.iso3166Field;
            }
            set
            {
                this.iso3166Field = value;
            }
        }

        /// <remarks/>
        public string geography
        {
            get
            {
                return this.geographyField;
            }
            set
            {
                this.geographyField = value;
            }
        }

        /// <remarks/>
        public uint start
        {
            get
            {
                return this.startField;
            }
            set
            {
                this.startField = value;
            }
        }

        /// <remarks/>
        public uint end
        {
            get
            {
                return this.endField;
            }
            set
            {
                this.endField = value;
            }
        }

        /// <remarks/>
        public string updated
        {
            get
            {
                return this.updatedField;
            }
            set
            {
                this.updatedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("row", IsNullable = false)]
        public eia_apiSeriesRowRow[] data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eia_apiSeriesRowRow
    {

        private uint dateField;

        private decimal valueField;

        /// <remarks/>
        public uint date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }

        /// <remarks/>
        public decimal value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


}
