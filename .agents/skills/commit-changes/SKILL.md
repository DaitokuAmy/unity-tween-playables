---
name: commit-changes
description: Inspect the current Git changes, split them into coherent commits, and create commits that follow this repository's message and staging rules. Use when asked to commit work, organize a mixed working tree into commits, or prepare focused commits from existing changes. Do not use for releasing or tagging the Unity package; use release-unity-package instead.
---

# Commit Changes

Create focused commits from the repository's existing changes without absorbing unrelated user work.

## Required context

Before staging or committing anything:

1. Read `AI.md` and applicable repository instructions.
2. Read `docs/rules/git-workflow.md` completely and treat it as the source of truth for commit format and Git operations.
3. Inspect `git status --short`, staged and unstaged diffs, and recent commit subjects.

If the rule file is absent or conflicts with an explicit user instruction, stop and explain the conflict before creating commits.

## Build the commit plan

- Classify every changed path by purpose and dependency.
- Separate independent changes into commits that can be reviewed and reverted independently.
- Keep implementation and its directly related tests or documentation together when separating them would leave a misleading or broken state.
- Keep formatting-only, generated-file, dependency, and unrelated maintenance changes separate from behavior changes.
- Preserve changes that are not part of the user's request. Do not discard, rewrite, or include them merely to make the tree clean.
- Present the proposed commit groups and subjects before committing when the grouping is ambiguous or the user asked to review the plan. Otherwise proceed with the best-supported grouping.

## Create each commit

For every planned group:

1. Stage only its paths or hunks. Prefer explicit paths and use patch staging when a file contains multiple concerns.
2. Review `git diff --cached --check`, `git diff --cached --stat`, and the full staged diff.
3. Run the smallest relevant validation required by the changed files. Do not silently skip a repository-required check.
4. Commit with the subject format defined in `docs/rules/git-workflow.md`.
5. Verify the created commit with `git show --stat --oneline --decorate HEAD` and confirm that no unrelated paths entered it.

Never amend, rebase, force-push, or bypass hooks unless the user explicitly requests that operation. Never use destructive cleanup to remove pre-existing changes.

## Finish

Report the commits in creation order with hashes and subjects, validations run, and any changes intentionally left uncommitted. Do not push unless the user explicitly requested a push.
