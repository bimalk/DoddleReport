﻿using System;

namespace DoddleReport
{
    public class RowField
    {
        private string _dataFormatString;

        public ReportRow Row { get; private set; }

        /// <summary>
        /// The ReportField that this row field is based on
        /// </summary>
        internal ReportField ReportField { get; set; }

        public Report Report
        {
            get { return Row.Report; }
        }

        /// <summary>
        /// Gets the name of the field
        /// </summary>
        public string Name { get; private set; }

        public Type DataType { get; internal set; }

        public string DataFormatString
        {
            get 
            { 
                return this._dataFormatString; 
            }

            set
            {
                this._dataFormatString = value;
                this.FormatAsDelegate = null;
            }
        }

        public string HeaderText { get; private set; }

        public bool Hidden { get; private set; }

        public ReportStyle DataStyle { get; private set; }
        public ReportStyle HeaderStyle { get; private set; }
        public ReportStyle FooterStyle { get; private set; }

        public bool ShowTotals { get; private set; }

        internal Delegate FormatAsDelegate { get; private set; }

		internal Delegate UrlDelegate { get; private set; }
		
		public RowField(ReportRow row, ReportField field)
        {
            Row = row;
            Hidden = field.Hidden;
            Name = field.Name;
            DataType = field.DataType;
            DataFormatString = field.DataFormatString;
            FormatAsDelegate = field.FormatAsDelegate;
            HeaderText = field.HeaderText;
            DataStyle = field.DataStyle.Copy();
            FooterStyle = field.FooterStyle;
            HeaderStyle = field.HeaderStyle;
            ShowTotals = field.ShowTotals;
			UrlDelegate = field.UrlDelegate;
        }

        public void FormatAs<T>(Func<T, string> formatAsDelegate)
        {
            this.DataFormatString = null;
            this.FormatAsDelegate = formatAsDelegate;
        }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }

        public override bool Equals(object obj)
        {
            var field = obj as RowField;
            if (field == null)
                return false;

            return field.ToString().Equals(ToString());
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}