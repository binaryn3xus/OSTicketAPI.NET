using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OSTicketAPI.NET.Enums;
using OSTicketAPI.NET.Helpers;
using OSTicketAPI.NET.Models;
using OSTicketAPI.NET.Tests.Attributes;
using OSTicketAPI.NET.Tests.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace OSTicketAPI.NET.Tests.Helpers
{
    public class OSTicketDecoderTests : IClassFixture<ConfigurationFixture>
    {
        private readonly ConfigurationFixture _fixture;
        private readonly ITestOutputHelper _testOutputHelper;

        public OSTicketDecoderTests(ConfigurationFixture fixture, ITestOutputHelper testOutputHelper)
        {
            _fixture = fixture;
            _testOutputHelper = testOutputHelper;
        }

        [RunnableInDebugOnly]
        public async Task JsonDecoderTests_ShouldThreadEventMessagesAsync()
        {
            var exceptions = new List<Exception>();
            var tickets = await _fixture.OSTicketService.Tickets.GetTickets().ConfigureAwait(false);
            var ticketsArray = tickets as Ticket[] ?? tickets.ToArray();
            var random = new Random();
            int randomIndex = random.Next(ticketsArray.Length);
            var ticket = ticketsArray[randomIndex];

            foreach (var ticketEvent in ticket.Events)
            {
                if (string.IsNullOrWhiteSpace(ticketEvent.Data))
                    continue;

                _testOutputHelper.WriteLine("Preparing to parse:");
                _testOutputHelper.WriteLine(ticketEvent.Data);
                try
                {
                    var ticketEventString = ticketEvent.ToFriendlyString();
                    _testOutputHelper.WriteLine(ticketEventString);
                    _testOutputHelper.WriteLine("------------------------");
                }
                catch (InvalidOperationException ioeEx)
                {
                    _testOutputHelper.WriteLine(ioeEx.Message);
                    _testOutputHelper.WriteLine(ticketEvent.Data);
                    exceptions.Add(ioeEx);
                }
            }
            Assert.Empty(exceptions);
        }

        [Fact]
        public void DecoderTests_ShouldDecodeFormFieldFlags()
        {
            //Test 'Optional' (13057)
            var flags = FormFieldFlagsDecoder.DecodeFlag(13057);
            Assert.Contains(FormFieldFlagsDecoder.FormFieldFlags.FlagEnabled, flags);

            //Test 'Required' (488739)
            flags = FormFieldFlagsDecoder.DecodeFlag(488739);
            Assert.Contains(FormFieldFlagsDecoder.FormFieldFlags.FlagClientRequired, flags);

            //Test 'Internal, Optional' (274609)
            flags = FormFieldFlagsDecoder.DecodeFlag(488739);
            Assert.Contains(FormFieldFlagsDecoder.FormFieldFlags.FlagAgentView, flags);
        }

        [Fact]
        public void DecoderTests_ShouldGetFriendlyMethodsResolved()
        {
            //Test 'Optional' (13057)
            var flags = FormFieldFlagsDecoder.DecodeFlag(13057).ToList();
            Assert.False(flags.IsRequiredForStaff());
            Assert.False(flags.IsRequiredForUsers());

            //Test 'Required For Agents Only' (29441)
            flags = FormFieldFlagsDecoder.DecodeFlag(29441).ToList();
            Assert.True(flags.IsRequiredForStaff());
            Assert.False(flags.IsRequiredForUsers());

            //Test 'Required For Users Only' (14081)
            flags = FormFieldFlagsDecoder.DecodeFlag(14081).ToList();
            Assert.False(flags.IsRequiredForStaff());
            Assert.True(flags.IsRequiredForUsers());

            //Test 'Internal' (12289)
            flags = FormFieldFlagsDecoder.DecodeFlag(12289).ToList();
            Assert.False(flags.IsVisibleToUsers());
            Assert.True(flags.IsVisibleToStaff());

            //Test 'For EndUsers Only' (8449)
            flags = FormFieldFlagsDecoder.DecodeFlag(8449).ToList();
            Assert.True(flags.IsVisibleToUsers());
            Assert.False(flags.IsVisibleToStaff());
        }
    }
}
