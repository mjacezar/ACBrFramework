// ***********************************************************************
// Assembly         : ACBrFramework.Net
// Author           : MarceloAlexandre
// Created          : 10-30-2014
//
// Last Modified By : RFTD
// Last Modified On : 10-29-2014
// ***********************************************************************
// <copyright file="IACBrDevice.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace ACBrFramework
{
    /// <summary>
    /// Interface IACBrDevice
    /// </summary>
    public interface IACBrDevice
    {
        /// <summary>
        /// Gets or sets the baud.
        /// </summary>
        /// <value>The baud.</value>
        int Baud { get; set; }

        /// <summary>
        /// Gets or sets the data bits.
        /// </summary>
        /// <value>The data bits.</value>
        int DataBits { get; set; }

        /// <summary>
        /// Gets or sets the hand shake.
        /// </summary>
        /// <value>The hand shake.</value>
        SerialHandShake HandShake { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [hard flow].
        /// </summary>
        /// <value><c>true</c> if [hard flow]; otherwise, <c>false</c>.</value>
        bool HardFlow { get; set; }

        /// <summary>
        /// Gets or sets the maximum bandwidth.
        /// </summary>
        /// <value>The maximum bandwidth.</value>
        int MaxBandwidth { get; set; }

        /// <summary>
        /// Gets or sets the parity.
        /// </summary>
        /// <value>The parity.</value>
        SerialParity Parity { get; set; }

        /// <summary>
        /// Gets or sets the porta.
        /// </summary>
        /// <value>The porta.</value>
        string Porta { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [process messages].
        /// </summary>
        /// <value><c>true</c> if [process messages]; otherwise, <c>false</c>.</value>
        bool ProcessMessages { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [soft flow].
        /// </summary>
        /// <value><c>true</c> if [soft flow]; otherwise, <c>false</c>.</value>
        bool SoftFlow { get; set; }

        /// <summary>
        /// Gets or sets the stop bits.
        /// </summary>
        /// <value>The stop bits.</value>
        SerialStopBits StopBits { get; set; }

        /// <summary>
        /// Gets or sets the time out.
        /// </summary>
        /// <value>The time out.</value>
        int TimeOut { get; set; }
    }
}