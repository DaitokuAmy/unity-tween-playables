---
name: release-unity-package
description: Release the Unity Package Manager package developed in this repository by selecting a SemVer bump from package changes, updating its version, validating it, creating focused commits, pushing the branch, and creating and pushing a numeric version tag. Use when asked to update, publish, or release the in-development Unity package. Do not use for ordinary commits that do not constitute a package release.
---

# Release Unity Package

Release `Packages/com.daitokuamy.unityluasystem` from the current branch. The package version is stored in `Packages/com.daitokuamy.unityluasystem/package.json`.

## Required context

Before changing files or Git state:

1. Read `AI.md` and applicable repository instructions.
2. Read `docs/rules/git-workflow.md` completely. Follow its commit, push, and tag rules as the source of truth.
3. Inspect the current branch, remote, working tree, package manifest, recent commits, and local and remote tags.
4. Fetch tags from the configured remote unless the user explicitly requires an offline-only operation.

Stop before release mutations if the branch has no upstream or remote, the target version or tag already exists locally or remotely, credentials are unavailable, or unrelated changes cannot be kept out of the release commits. Report the exact blocker; do not guess or force the operation.

## Determine the release contents and version

- Limit release analysis to changes that affect the package or its consumer-facing documentation and release metadata.
- Compare package-relevant changes since the latest reachable numeric version tag. If no such tag exists, inspect package history and ask for the intended baseline only when it cannot be inferred safely.
- Apply Semantic Versioning:
  - `major`: incompatible public API or behavior changes.
  - `minor`: backward-compatible functionality or public API additions.
  - `patch`: backward-compatible fixes, performance improvements, and package-facing documentation or metadata corrections.
- Use the highest bump required by any included change. A user-specified version wins if it is valid and greater than the current package version; call out any mismatch with the observed change level.
- Do not create a release when no package-relevant change exists unless the user explicitly requests an empty or metadata-only release.

## Prepare and validate

1. Define the exact release commit groups before staging. Keep unrelated working-tree changes untouched.
2. Commit non-version package work in focused commits when it is not already committed, following `docs/rules/git-workflow.md`.
3. Update only the manifest `version` field to the selected version unless another release file is required by repository rules.
4. Validate JSON syntax, confirm the manifest name and version, run `git diff --check`, and run the repository's relevant package or Unity tests when available.
5. Create the version commit using the subject required by `docs/rules/git-workflow.md`.

If validation fails, stop before push or tag creation and report the failure. Do not bypass hooks or tests.

## Publish the release

1. Re-read the commits that will be pushed and verify that the version commit is included.
2. Push the current branch normally; never force-push.
3. Create the tag exactly as the manifest version, for example `0.8.0`, on the verified release commit. Do not prefix it with `v`.
4. Verify that the tag resolves to the intended commit and that its name equals the manifest version.
5. Push that exact tag explicitly.
6. Read back the remote branch and tag state where possible.

Do not move or replace an existing tag. If branch push succeeds but tag creation or tag push fails, stop and report the partial state and the safe retry point.

## Finish

Report the released package version, version-bump rationale, created commits, validations, pushed branch, and pushed tag. List any unrelated changes left in the working tree.
