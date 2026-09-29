# Following matters are represented

- Test coverage
    - Unit testing
    - Documentation through scenario based testing.
- Fine grained structuring/layering
    - Domain layer completely isolated from any dependencies.
    - Application layer is also dealing with command/query/services but no infrastructure or UI.
- State management through event sourcing
    - separating reads from writes via CQRS.
    - possible to revive the state in case of crash/restart.
