//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
// <copyright file="Refund.cs" company="SCVNGR, Inc. d/b/a LevelUp">
//   Copyright(c) 2015 SCVNGR, Inc. d/b/a LevelUp. All rights reserved.
// </copyright>
// <license publisher="Apache Software Foundation" date="January 2004" version="2.0">
//   Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except
//   in compliance with the License. You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software distributed under the License
//   is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
//   or implied. See the License for the specific language governing permissions and limitations under
//   the License.
// </license>
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

using Newtonsoft.Json;

namespace LevelUp.Api.Client.Models.Requests
{
    /// <summary>
    /// Class representing a request for a LevelUp refund
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Refund
    {
        /// <summary>
        /// Constructor for creating a LevelUp refund request
        /// </summary>
        /// <param name="managerConfirmation">A manager confirmation string if required by the POS system. 
        /// Default is null</param>
        public Refund(string managerConfirmation = null)
        {
            RefundContainer = new RefundContainer(managerConfirmation);
        }

        /// <summary>
        /// A manager refund confirmation string. May be null.
        /// </summary>
        public string ManagerConfirmation { get { return RefundContainer.ManagerConfirmation; } }

        /// <summary>
        /// Use this container to aid in correct JSON serialization
        /// </summary>
        [JsonProperty(PropertyName = "refund")]
        private RefundContainer RefundContainer { get; set; }
    }
}
