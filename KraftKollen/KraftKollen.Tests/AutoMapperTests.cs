using AutoMapper;
using KraftKollen.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KraftKollen.Tests
{
    public class AutoMapperTests
    {
        // Validates that DTO can map to Domain/View model
        [Fact]
        public void AutoMapper_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            config.AssertConfigurationIsValid();
        }
    }
}
