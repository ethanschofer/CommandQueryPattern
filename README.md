# SimpleCQRS

A simple CQRS architecture. This is NOT using event sourcing. It is simply separating the querying of the data source and adding/updating the data source.

In addition, this architecture implements the mediator pattern to assist in removing code from controllers, and putting it in the command and query handlers.

Each controller will need to have a QueryDispatcher and a CommandDispatcher. A simple way to do this is to create a base controller, and inject the QueryDispatcher and CommandDispatcher at construction.

