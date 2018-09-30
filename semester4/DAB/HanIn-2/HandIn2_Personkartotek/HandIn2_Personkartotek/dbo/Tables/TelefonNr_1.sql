CREATE TABLE [TelefonNr] (
  [SelskabID] uint,
  [Selskabnavn] string,
  PRIMARY KEY ([SelskabID])
);
GO
CREATE INDEX [FK] ON  [TelefonNr] ([Ejer], [Telefonselskab]);