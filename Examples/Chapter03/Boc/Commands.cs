﻿using System;

namespace Boc.Commands
{
   public abstract record Command(DateTime Timestamp);

   public record MakeTransfer
   (
      Guid DebitedAccountId,

      string Beneficiary,
      string Iban,
      string Bic,

      DateTime Date,
      decimal Amount,
      string Reference,

      DateTime Timestamp = default
   )
      : Command(Timestamp)
   {
      // useful for testing, when you don't need all the properties to be populated
      internal static MakeTransfer Dummy
         => new(default, default, default, default, default, default, default);
   }

   public static class CommandExt
   {
      // when a command is receieved by the server, set a timestamp
      public static T SetTimestamp<T>(this T cmd) where T : Command
         => cmd with { Timestamp = DateTime.UtcNow };
   }
}
