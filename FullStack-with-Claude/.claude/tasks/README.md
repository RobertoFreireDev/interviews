# Task Workflow

## Lifecycle
```
backlog/  →  active/  →  done/
```

- **backlog/** — defined, not started. One file per task.
- **active/** — keep to 1 task at a time. Claude reads this + the context files it lists.
- **done/** — completed tasks. Archive only, never re-opened.

## Commands (invoke with `/`)

| Command | What it does |
|---------|-------------|
| `/new-task <title>` | Scaffold a new task file in `backlog/` |
| `/start-task <filename>` | Move task to `active/`, confirm plan |
| `/task <filename>` | Execute the active task step by step |

## Task file rules
- Every task lists its **Scope** (directories). Claude reads nothing outside that scope.
- Every task links its **Context** files from `.claude/context/`. No inline domain docs.
- Acceptance criteria use `- [ ]` checkboxes — Claude checks them off as it works.
