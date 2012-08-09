C# Assorted code
=======================

Miscellaneous C# programs, experiments and code samples

* `\SQLHelper\` : Small SQL Server helper to quickly operate with stored procedures for performing typical CRUD operations. Works with DataTables, DataRows or scalars to minimize CPU/memory footprint, uses generics to automatically map .NET types with MSSQL types (not all are implemented), and while not really decoupled from the SQL engine the goal was to forget about SQL types outside of the Storage layer (instead of building an ODBC like abstraction).
Tests will probably be added in the future.
* `\Delegate_AI_Ex\` : Example of how C# Delegates (function pointers) can easily be used in a videogame's Artificial Intelligence code, by easily switching behaviours.
