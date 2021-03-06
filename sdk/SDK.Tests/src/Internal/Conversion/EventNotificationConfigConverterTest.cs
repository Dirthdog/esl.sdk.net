using NUnit.Framework;
using System;
using Silanis.ESL.SDK;
using Silanis.ESL.API;

namespace SDK.Tests
{
    [TestFixture()]
    public class EventNotificationConfigConverterTest
    {
		private Silanis.ESL.API.Callback apiCallback1 = null;
		private Silanis.ESL.API.Callback apiCallback2 = null;
		private Silanis.ESL.SDK.EventNotificationConfig sdkEventNotificationConfig1 = null;
		private Silanis.ESL.SDK.EventNotificationConfig sdkEventNotificationConfig2 = null;
		private EventNotificationConfigConverter converter;

		[Test()]
		public void convertNullSDKToAPI() {
			sdkEventNotificationConfig1 = null;
			converter = new EventNotificationConfigConverter(sdkEventNotificationConfig1);
			Assert.IsNull(converter.ToAPICallback());
		}

		[Test()]
		public void convertNullAPIToSDK() {
			apiCallback1 = null;
			converter = new EventNotificationConfigConverter(apiCallback1);
			Assert.IsNull(converter.ToSDKEventNotificationConfig());
		}

		[Test()]
		public void convertNullSDKToSDK() {
			sdkEventNotificationConfig1 = null;
			converter = new EventNotificationConfigConverter(sdkEventNotificationConfig1);
			Assert.IsNull(converter.ToSDKEventNotificationConfig());
		}

		[Test()]
		public void convertNullAPIToAPI() {
			apiCallback1 = null;
			converter = new EventNotificationConfigConverter(apiCallback1);
			Assert.IsNull(converter.ToAPICallback());
		}

		[Test()]
		public void convertSDKToSDK() {
			sdkEventNotificationConfig1 = CreateTypicalSDKEventNotificationConfig();
			sdkEventNotificationConfig2 = new EventNotificationConfigConverter(sdkEventNotificationConfig1).ToSDKEventNotificationConfig();

			Assert.IsNotNull(sdkEventNotificationConfig2);
			Assert.AreEqual(sdkEventNotificationConfig2, sdkEventNotificationConfig1);
		}

		[Test()]
		public void convertAPIToAPI() {
			apiCallback1 = CreateTypicalAPICallback();
			apiCallback2 = new EventNotificationConfigConverter(apiCallback1).ToAPICallback();

			Assert.IsNotNull(apiCallback2);
			Assert.AreEqual(apiCallback2, apiCallback1);
		}

		[Test()]
		public void convertAPIToSDK() {
			apiCallback1 = CreateTypicalAPICallback();
			sdkEventNotificationConfig1 = new EventNotificationConfigConverter(apiCallback1).ToSDKEventNotificationConfig();

			Assert.IsNotNull(sdkEventNotificationConfig1);
			Assert.AreEqual(sdkEventNotificationConfig1.Url, apiCallback1.Url);
			Assert.AreEqual(sdkEventNotificationConfig1.NotificationEvents.Count, 3);
			Assert.AreEqual(sdkEventNotificationConfig1.NotificationEvents[0].ToString(), apiCallback1.Events[0].ToString());
			Assert.AreEqual(sdkEventNotificationConfig1.NotificationEvents[1].ToString(), apiCallback1.Events[1].ToString());
			Assert.AreEqual(sdkEventNotificationConfig1.NotificationEvents[2].ToString(), apiCallback1.Events[2].ToString());
		}

		
		[Test()]
		public void convertSDKToAPI() {
			sdkEventNotificationConfig1 = CreateTypicalSDKEventNotificationConfig();
			apiCallback1 = new EventNotificationConfigConverter(sdkEventNotificationConfig1).ToAPICallback();

			Assert.IsNotNull(apiCallback1);
			Assert.AreEqual(apiCallback1.Url, sdkEventNotificationConfig1.Url);
			Assert.AreEqual(apiCallback1.Events.Count, 3);
			Assert.AreEqual(apiCallback1.Events[0].ToString(), sdkEventNotificationConfig1.NotificationEvents[0].ToString());
			Assert.AreEqual(apiCallback1.Events[1].ToString(), sdkEventNotificationConfig1.NotificationEvents[1].ToString());
			Assert.AreEqual(apiCallback1.Events[2].ToString(), sdkEventNotificationConfig1.NotificationEvents[2].ToString());
		}

		private Silanis.ESL.API.Callback CreateTypicalAPICallback() {
			Callback callback = new Callback();
			callback.Url = "callback url";
			callback.AddEvent(CallbackEvent.DOCUMENT_SIGNED);
			callback.AddEvent(CallbackEvent.PACKAGE_CREATE);
			callback.AddEvent(CallbackEvent.PACKAGE_TRASH);

			return callback;
		}

		private Silanis.ESL.SDK.EventNotificationConfig CreateTypicalSDKEventNotificationConfig() {
			EventNotificationConfig eventNotificationConfig = EventNotificationConfigBuilder.NewEventNotificationConfig("callback url")
				.ForEvent(NotificationEvent.PACKAGE_DECLINE)
				.ForEvent(NotificationEvent.PACKAGE_RESTORE)
				.ForEvent(NotificationEvent.SIGNER_COMPLETE)
				.build();

			return eventNotificationConfig;
		}
    }
}

