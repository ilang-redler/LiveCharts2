﻿// The MIT License(MIT)
//
// Copyright(c) 2021 Alberto Rodriguez Orozco & LiveCharts Contributors
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using LiveChartsCore.Kernel;
using Windows.UI.Text;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace LiveChartsCore.SkiaSharpView.Uno;

/// <summary>
/// The Uwp poing class, just used to bind the tooltips.
/// </summary>
[Bindable]
public class BindingPoint
{
    /// <summary>
    /// Ges the chart point.
    /// </summary>
    public BindableChartPoint ChartPoint { get; set; } = null!;

    /// <summary>
    /// Gets the font family.
    /// </summary>
    public FontFamily FontFamily { get; set; } = null!;

    /// <summary>
    /// Gets the foreground.
    /// </summary>
    public Brush Foreground { get; set; } = null!;

    /// <summary>
    /// Gets the font size.
    /// </summary>
    public double FontSize { get; set; }

    /// <summary>
    /// Gets the font weight.
    /// </summary>
    public FontWeight FontWeight { get; set; }

    /// <summary>
    /// Gets the font style.
    /// </summary>
    public FontStyle FontStyle { get; set; }

    /// <summary>
    /// Gets the font stretch.
    /// </summary>
    public FontStretch FontStretch { get; set; }
}

/// <summary>
/// 
/// </summary>
[Bindable]
public class BindableChartPoint
{
    private readonly ChartPoint _chartPoint;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChartPoint"/> class.
    /// </summary>
    /// <param name="chartpoint">The chartpoint.</param>
    public BindableChartPoint(ChartPoint chartpoint)
    {
        _chartPoint = chartpoint;

        IsNull = chartpoint.IsNull;
        PrimaryValue = chartpoint.PrimaryValue;
        SecondaryValue = chartpoint.SecondaryValue;
        TertiaryValue = chartpoint.TertiaryValue;
        QuaternaryValue = chartpoint.QuaternaryValue;
        QuinaryValue = chartpoint.QuinaryValue;

        if (chartpoint.StackedValue is not null)
        {
            StackedValue = new BindableStackedValue
            {
                Start = chartpoint.StackedValue.Start,
                End = chartpoint.StackedValue.End,
                Total = chartpoint.StackedValue.Total,
                NegativeStart = chartpoint.StackedValue.NegativeStart,
                NegativeEnd = chartpoint.StackedValue.NegativeEnd,
                NegativeTotal = chartpoint.StackedValue.NegativeTotal,
            };
        }

        Context = new BindableChartPointContext(chartpoint.Context);
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is null.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is null; otherwise, <c>false</c>.
    /// </value>
    public bool IsNull { get; set; }

    /// <summary>
    /// Gets or sets the primary value.
    /// </summary>
    /// <value>
    /// The primary value.
    /// </value>
    public double PrimaryValue { get; set; }

    /// <summary>
    /// Gets or sets the secondary value.
    /// </summary>
    /// <value>
    /// The secondary value.
    /// </value>
    public double SecondaryValue { get; set; }

    /// <summary>
    /// Gets or sets the tertiary value.
    /// </summary>
    /// <value>
    /// The tertiary value.
    /// </value>
    public double TertiaryValue { get; set; }

    /// <summary>
    /// Gets or sets the quaternary value.
    /// </summary>
    /// <value>
    /// The quaternary value.
    /// </value>
    public double QuaternaryValue { get; set; }

    /// <summary>
    /// Gets or sets the quinary value.
    /// </summary>
    /// <value>
    /// The quinary value.
    /// </value>
    public double QuinaryValue { get; set; }

    /// <summary>
    /// Gets or sets the stacked value, if the point do not belongs to a stacked series then this property is null.
    /// </summary>
    public BindableStackedValue? StackedValue { get; set; }

    /// <summary>
    /// Gets the point as tooltip string.
    /// </summary>
    /// <value>
    /// As tooltip string.
    /// </value>
    public string AsTooltipString => _chartPoint.Context.Series.GetTooltipText(_chartPoint);

    /// <summary>
    /// Gets the point as data label.
    /// </summary>
    /// <value>
    /// As tooltip string.
    /// </value>
    public string AsDataLabel => _chartPoint.Context.Series.GetDataLabelText(_chartPoint);

    /// <summary>
    /// Gets the context.
    /// </summary>
    /// <value>
    /// The context.
    /// </value>
    public BindableChartPointContext Context { get; }
}


/// <summary>
/// 
/// </summary>
[Bindable]
public class BindableStackedValue
{
    /// <summary>
    /// Gets or sets the start.
    /// </summary>
    /// <value>
    /// The start.
    /// </value>
    public double Start { get; set; }

    /// <summary>
    /// Gets or sets the end.
    /// </summary>
    /// <value>
    /// The end.
    /// </value>
    public double End { get; set; }

    /// <summary>
    /// Gets or sets the total stacked.
    /// </summary>
    /// <value>
    /// The total.
    /// </value>
    public double Total { get; set; }

    /// <summary>
    /// Gets or sets the start.
    /// </summary>
    /// <value>
    /// The start.
    /// </value>
    public double NegativeStart { get; set; }

    /// <summary>
    /// Gets or sets the end.
    /// </summary>
    /// <value>
    /// The end.
    /// </value>
    public double NegativeEnd { get; set; }

    /// <summary>
    /// Gets or sets the total stacked.
    /// </summary>
    /// <value>
    /// The total.
    /// </value>
    public double NegativeTotal { get; set; }
}

/// <summary>
/// 
/// </summary>
[Bindable]
public class BindableChartPointContext
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="chartPointContext"></param>
    public BindableChartPointContext(ChartPointContext chartPointContext)
    {
        Chart = chartPointContext.Chart;
        Series = chartPointContext.Series;
        Index = chartPointContext.Index;
        DataSource = chartPointContext.DataSource;
        Visual = chartPointContext.Visual;
        Label = chartPointContext.Label;
    }

    /// <summary>
    /// Gets the chart.
    /// </summary>
    /// <value>
    /// The chart.
    /// </value>
    public object Chart { get; }

    /// <summary>
    /// Gets the series.
    /// </summary>
    /// <value>
    /// The series.
    /// </value>
    public object Series { get; }

    /// <summary>
    /// Gets the position of the point the collection that was used when the point was drawn.
    /// </summary>
    public int Index { get; internal set; }

    /// <summary>
    /// Gets the DataSource.
    /// </summary>
    public object? DataSource { get; internal set; }

    /// <summary>
    /// Gets the visual.
    /// </summary>
    /// <value>
    /// The visual.
    /// </value>
    public object? Visual { get; internal set; }

    /// <summary>
    /// Gets the label.
    /// </summary>
    /// <value>
    /// The label.
    /// </value>
    public object? Label { get; internal set; }
}
