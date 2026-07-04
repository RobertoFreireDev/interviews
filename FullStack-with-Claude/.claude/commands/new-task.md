Create a new task file in `.claude/tasks/backlog/` using the next available number.

The task file must follow this structure exactly:

```
# Task NNN — <title>

## Context
Read `.claude/context/<relevant>.md` before starting.

## Goal
<one paragraph>

## Scope
- Directory: `<dir>/`
- Do not touch: <other dirs>

## Acceptance criteria
- [ ] <criterion 1>
- [ ] <criterion 2>

## Out of scope
- <item>
```

Use $ARGUMENTS as the task title and goal. Ask me for acceptance criteria if not provided.
