﻿#region Copyright (Apache 2.0)
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
// <copyright file="CreateProposedOrderRequestBody.cs" company="SCVNGR, Inc. d/b/a LevelUp">
//   Copyright(c) 2016 SCVNGR, Inc. d/b/a LevelUp. All rights reserved.
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
#endregion

using System.Collections.Generic;
using Newtonsoft.Json;

namespace LevelUp.Api.Client.Models.Requests
{
    [JsonObject(MemberSerialization.OptIn)]
    [LevelUpSerializableModel("proposed_order")]
    [JsonConverter(typeof(LevelUpModelSerializer))]
    public class CreateProposedOrderRequestBody
    {
        private CreateProposedOrderRequestBody()
        {
            // Private constructor for deserialization
        }

        public CreateProposedOrderRequestBody( int locationId,
                                         string qrPaymentData,
                                         int spendAmountCents,
                                         int? taxAmountCents,
                                         int exemptionAmountCents,
                                         string register,
                                         string cashier,
                                         string identifierFromMerchant,
                                         string receiptMessageHtml,
                                         bool partialAuthorizationAllowed,
                                         IList<Item> items)
        {
            LocationId = locationId;
            PaymentData = qrPaymentData;
            SpendAmountCents = spendAmountCents;
            TaxAmountCents = taxAmountCents;
            ExemptionAmountCents = exemptionAmountCents;
            Register = register;
            Cashier = cashier;
            Identifier = identifierFromMerchant;
            RecieptMessage = receiptMessageHtml;
            PartialAuthorizationAllowed = partialAuthorizationAllowed;
            ItemsInternal = items;
        }

        [JsonProperty(PropertyName = "location_id")]
        public int LocationId { get; private set; }

        [JsonProperty(PropertyName = "spend_amount")]
        public int SpendAmountCents { get; private set; }

        [JsonProperty(PropertyName = "tax_amount")]
        public int? TaxAmountCents { get; private set; }

        [JsonProperty(PropertyName = "cashier")]
        public string Cashier { get; private set; }

        [JsonProperty(PropertyName = "register")]
        public string Register { get; private set; }

        [JsonProperty(PropertyName = "exemption_amount")]
        public int ExemptionAmountCents { get; private set; }

        [JsonProperty(PropertyName = "partial_authorization_allowed")]
        public bool PartialAuthorizationAllowed { get; private set; }

        [JsonProperty(PropertyName = "payment_token_data")]
        public string PaymentData { get; private set; }

        [JsonProperty(PropertyName = "receipt_message_html")]
        public string RecieptMessage { get; private set; }

        [JsonProperty(PropertyName = "identifier_from_merchant")]
        public string Identifier { get; private set; }

        [JsonIgnore]
        public IList<Item> Items
        {
            get { return Item.CopyList(ItemsInternal); }
        }

        [JsonProperty(PropertyName = "items")]
        private IList<Item> ItemsInternal { get; set; }
    }
}
