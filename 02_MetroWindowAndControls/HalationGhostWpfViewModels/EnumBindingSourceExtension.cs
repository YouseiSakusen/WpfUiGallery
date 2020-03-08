using System;
using System.Windows.Markup;

namespace HalationGhost.WinApps
{
	/// <summary>enum値を生成するためのマークアップ拡張。</summary>
	public class EnumBindingSourceExtension : MarkupExtension
	{
		/// <summary>対象のenum型を表します。</summary>
		private Type _enumType;

		/// <summary>生成するenumの型を取得・設定します。</summary>
		public Type EnumType
		{
			get { return _enumType; }
			set
			{
				if (value != this._enumType)
				{
					if (null != value)
					{
						Type enumType = Nullable.GetUnderlyingType(value) ?? value;
						if (!enumType.IsEnum)
							throw new ArgumentException("Type must be for an Enum.");
					}

					this._enumType = value;
				}
			}
		}

		/// <summary>生成した値を取得します。</summary>
		/// <param name="serviceProvider">マークアップ拡張機能のサービスを提供できるサービス プロバイダーのヘルパー。</param>
		/// <returns>生成した値を表すobject。</returns>
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			if (null == this._enumType)
				throw new InvalidOperationException("The EnumType must be specified.");

			Type actualEnumType = Nullable.GetUnderlyingType(this._enumType) ?? this._enumType;
			Array enumValues = Enum.GetValues(actualEnumType);

			if (actualEnumType == this._enumType)
				return enumValues;

			Array tempArray = Array.CreateInstance(actualEnumType, enumValues.Length + 1);
			enumValues.CopyTo(tempArray, 1);
			return tempArray;
		}

		/// <summary>デフォルトコンストラクタ。</summary>
		public EnumBindingSourceExtension() { }

		/// <summary>コンストラクタ。</summary>
		/// <param name="enumType">生成するenumの型を表すType。</param>
		public EnumBindingSourceExtension(Type enumType)
			=> this.EnumType = enumType;
	}
}
