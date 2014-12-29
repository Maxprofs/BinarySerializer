﻿using System;

namespace BinarySerialization
{
    /// <summary>
    /// Defines a binding to a member.
    /// </summary>
    /// <seealso cref="BinarySerializer"/>
    public class BindingInfo
    {
        /// <summary>
        /// Initializes a new BindingInfo.
        /// </summary>
        internal BindingInfo()
        {
        }

        /// <summary>
        /// Initializes a new BindingInfo with a path, a source binding mode, and an optional converter. 
        /// </summary>
        /// <param name="path">The path to the source member.</param>
        /// <param name="mode">The source mode.</param>
        /// <param name="converterType">An optional converter.</param>
        /// <param name="converterParameter">An optional converter parameter.</param>
        internal BindingInfo(string path, RelativeSourceMode mode, Type converterType = null,
            object converterParameter = null)
        {
            Path = path;
            Mode = mode;
            ConverterType = converterType;
            ConverterParameter = converterParameter;
        }

        /// <summary>
        /// Initializes a new BindingInfo with a path and an optional converter.
        /// using mode <see cref="RelativeSourceMode.Self"/>.
        /// </summary>
        /// <param name="path">The path to the source member.</param>
        /// <param name="converterType">An optional converter.</param>
        /// <param name="converterParameter">An optional converter parameter.</param>
        internal BindingInfo(string path, Type converterType = null, object converterParameter = null)
            : this(path, RelativeSourceMode.Self, converterType, converterParameter)
        {
        }

        /// <summary>
        /// Gets or sets the path to the binding source member.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the level of ancestor to look for, in <see cref="RelativeSourceMode.FindAncestor"/> mode. 
        /// Use 1 to indicate the one nearest to the binding target element.
        /// </summary>
        public int AncestorLevel { get; set; }

        /// <summary>
        /// Gets or sets the type of ancestor to look for.
        /// </summary>
        public Type AncestorType { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="RelativeSourceMode"/> value that describes the location of the
        /// binding source member relative to the position of the binding target.
        /// </summary>
        public RelativeSourceMode Mode { get; set; }

        /// <summary>
        /// An optional converter to be used converting from the source value to the target binding.
        /// </summary>
        public Type ConverterType { get; set; }

        /// <summary>
        /// An optional converter parameter to be passed to the converter.
        /// </summary>
        public object ConverterParameter { get; set; }

        protected bool Equals(BindingInfo other)
        {
            return string.Equals(Path, other.Path) && AncestorLevel == other.AncestorLevel &&
                   AncestorType == other.AncestorType && ConverterType == other.ConverterType && Mode == other.Mode &&
                   Equals(ConverterParameter, other.ConverterParameter);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((BindingInfo) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Path != null ? Path.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ AncestorLevel;
                hashCode = (hashCode*397) ^ (AncestorType != null ? AncestorType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ConverterType != null ? ConverterType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) Mode;
                hashCode = (hashCode*397) ^ (ConverterParameter != null ? ConverterParameter.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}