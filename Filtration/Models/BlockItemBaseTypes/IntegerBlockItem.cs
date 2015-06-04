﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using Filtration.Annotations;

namespace Filtration.Models.BlockItemBaseTypes
{
    internal abstract class IntegerBlockItem : ILootFilterBlockItem, IAudioVisualBlockItem
    {
        private int _value;

        protected IntegerBlockItem()
        {
        }

        protected IntegerBlockItem(int value)
        {
            Value = value;
        }

        public abstract string PrefixText { get; }
        public abstract int MaximumAllowed { get; }

        public abstract string DisplayHeading { get; }

        public string SummaryText { get { return string.Empty; } }
        public Color SummaryBackgroundColor { get { return Colors.Transparent; } }
        public Color SummaryTextColor { get { return Colors.Transparent; } }
        public abstract int SortOrder { get; }

        public abstract int Minimum { get; }
        public abstract int Maximum { get; }

        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}