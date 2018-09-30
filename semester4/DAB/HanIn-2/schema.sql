CREATE TABLE [Adresse] (
  [AdresseID] uint,
  [Vejnavn] string,
  [HusNr] uint,
  [By] ByID,
  PRIMARY KEY ([AdresseID])
);

CREATE INDEX [FK] ON  [Adresse] ([By]);

CREATE TABLE [Person] (
  [PersonID] uint,
  [Prmær Adresse] AdresseID,
  [Fornavn] string,
  [Mellemnavn] string,
  [Efternavn] string,
  [email  adresse] string,
  [Noter] string,
  PRIMARY KEY ([PersonID])
);

CREATE INDEX [FK] ON  [Person] ([Prmær Adresse]);

CREATE TABLE [Alternativ Adresse] (
  [PersonID?AdresseID] <type>,
  [type] <type>
);

CREATE INDEX [PK, FK1?PK, FK2] ON  [Alternativ Adresse] ([PersonID?AdresseID]);

CREATE TABLE [By] (
  [ByID] uint,
  [Bynavn] string,
  [PostNr] string,
  [Land] LandID,
  PRIMARY KEY ([ByID])
);

CREATE INDEX [FK] ON  [By] ([Land]);

CREATE TABLE [Land] (
  [LandID] uint,
  [Landenavn] string,
  [Landekode] string,
  PRIMARY KEY ([LandID])
);

CREATE TABLE [TelefonNr] (
  [Nummer] string,
  [Ejer] PersoID,
  [type] string,
  [Telefonselskab] SelskabID,
  PRIMARY KEY ([Nummer])
);

CREATE INDEX [FK] ON  [TelefonNr] ([Ejer], [Telefonselskab]);

CREATE TABLE [TelefonNr] (
  [SelskabID] uint,
  [Selskabnavn] string,
  PRIMARY KEY ([SelskabID])
);

