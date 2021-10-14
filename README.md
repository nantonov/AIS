# AIS
![dotnet workflow](https://github.com/nantonov/AIS/actions/workflows/dotnet.yml/badge.svg)
![dotnet workflow](https://github.com/nantonov/AIS/actions/workflows/codeql-analysis.yml/badge.svg)

![Alt-текст](https://bitworks.software/assets/img/2018-12-11/Feature.png "Gitflow")

# Branches types

#### Main - main branch for project.
#### feature/* - branches for new features.
#### bug/* - branches for fix something that went wrong.

# Work steps

When you take any task you should create new branch named 'feature/WHAT_YOU_WILL_DO'.
After creating branch you should create merge(pull) request into main.

When you'll complete the task you should wait two approvers. If you have < 2 approvers you can't merge the branch.
If messages was left approvers and this messages are bugs, you have to fix it.

If you have >= 2 approvers, you can merge this branch. If after merge branch doesn't delete, you'll should delete it via your hands.
After, when you take another task, you should repeat this steps.
