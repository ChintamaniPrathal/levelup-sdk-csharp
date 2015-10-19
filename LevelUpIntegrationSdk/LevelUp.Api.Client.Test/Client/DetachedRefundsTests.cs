//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
// <copyright file="DetachedRefundsTests.cs" company="SCVNGR, Inc. d/b/a LevelUp">
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

using LevelUp.Api.Client.Models.Requests;
using LevelUp.Api.Client.Models.Responses;
using LevelUp.Api.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LevelUp.Api.Client.Test
{
    [TestClass]
    [DeploymentItem("LevelUpBaseUri.txt")]
    [DeploymentItem("test_config_settings.xml")]
    public class DetachedRefundsTests : ApiUnitTestsBase
    {
        [TestMethod]
        [Ignore]
        public void CreateSucceeds_WhenQrCodeValid()
        {
            DetachedRefundResponse response = CreateDetachedRefund(AccessToken.Token, 
                                                                   LevelUpTestConfiguration.Current.User_PaymentToken, 
                                                                   EXPECTED_SPEND_AMOUNT_CENTS);
            Assert.IsNotNull(response);
            Assert.AreEqual(EXPECTED_SPEND_AMOUNT_CENTS, response.CreditAmountCents);
        }

        [TestMethod]
        [ExpectedException(typeof(LevelUpApiException))]
        [Ignore]
        public void CreateFails_WhenQrCodeIsInvalid()
        {
            const int expectedStatus = (int)HttpStatusCodeExtended.UnprocessableEntity;
            const string expectedErrorMessage = "Invalid QR code";

            try
            {
                CreateDetachedRefund(AccessToken.Token,
                                     LevelUpTestConfiguration.Current.User_InvalidPaymentToken, EXPECTED_SPEND_AMOUNT_CENTS);
                Assert.Fail("Expected LevelUpApiException on refund with bad Qr data but did not catch it!");
            }
            catch (LevelUpApiException luEx)
            {
                // Catch expected exception
                Assert.AreEqual(expectedStatus, (int)luEx.StatusCode); //This currently fails with status 404 instead of the more correct 422
                Assert.IsTrue(luEx.Message.ToLower().Contains(expectedErrorMessage.ToLower()));
                throw;
            }
        }

        private DetachedRefundResponse CreateDetachedRefund(string accessToken, 
                                                            string qrCodeToUse, 
                                                            int creditAmountInCents)
        {
            DetachedRefund refund = new DetachedRefund(LevelUpTestConfiguration.Current.Merchant_LocationId_Visible,
                                                       qrCodeToUse,
                                                       creditAmountInCents);

            return Api.CreateDetachedRefund(accessToken, refund);
        }
    }
}