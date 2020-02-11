using System;
using System.Collections.Generic;
using System.Linq;

namespace OSTicketAPI.NET.Enums
{
    public static class FormFieldFlagsDecoder
    {
        [Flags]
        public enum FormFieldFlags
        {
            None = 0,
            FlagEnabled = 0x00001,
            FlagExtStored = 0x00002,
            FlagCloseRequired = 0x00004,
            FlagMaskChange = 0x00010,
            FlagMaskDelete = 0x00020,
            FlagMaskEdit = 0x00040,
            FlagMaskDisable = 0x00080,
            FlagClientView = 0x00100,
            FlagClientEdit = 0x00200,
            FlagClientRequired = 0x00400,
            MaskClientFull = 0x00700,
            FlagAgentView = 0x01000,
            FlagAgentEdit = 0x02000,
            FlagAgentRequired = 0x04000,
            MaskAgentFull = 0x7000,
            FlagMaskRequire = 0x10000,
            FlagMaskView = 0x20000,
            FlagMaskName = 0x40000,
            MaskMaskInternal = 0x400B2,
            MaskMaskAll = 0x700F2
        }

        public static IEnumerable<FormFieldFlags> DecodeFlag(int? flagValue)
        {
            if (!flagValue.HasValue)
                return new List<FormFieldFlags>();

            var mask = (FormFieldFlags)flagValue;
            var result = Enum.GetValues(typeof(FormFieldFlags))
                .Cast<FormFieldFlags>()
                .Where(value => mask.HasFlag(value))
                .ToList();
            return result;
        }

        public static bool IsVisibleToUsers(this IEnumerable<FormFieldFlags> collection)
        {
            var formFieldFlags = collection.ToList();
            return formFieldFlags.Contains(FormFieldFlags.FlagEnabled) && formFieldFlags.Contains(FormFieldFlags.FlagClientView);
        }

        public static bool IsVisibleToStaff(this IEnumerable<FormFieldFlags> collection)
        {
            var formFieldFlags = collection.ToList();
            return formFieldFlags.Contains(FormFieldFlags.FlagEnabled) && formFieldFlags.Contains(FormFieldFlags.FlagAgentView);
        }

        public static bool IsRequiredForUsers(this IEnumerable<FormFieldFlags> collection)
        {
            return collection.Contains(FormFieldFlags.FlagClientRequired);
        }

        public static bool IsRequiredForStaff(this IEnumerable<FormFieldFlags> collection)
        {
            return collection.Contains(FormFieldFlags.FlagAgentRequired);
        }

        public static bool IsRequiredForClose(this IEnumerable<FormFieldFlags> collection)
        {
            return collection.Contains(FormFieldFlags.FlagCloseRequired);
        }
    }
}
