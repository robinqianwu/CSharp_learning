1. Git 文件用来记录一些学习Git的心得

- Git 从结构上说可以理解为Cloud Serve Repository部分和本地的Git Repository
- 一般提交的过程可以了理解为，在本地提交修改的文件到本地的Repository，然后在push到云端
  -- 在本地提交的过程可以为：
    --- 直接 commit 到本地， 然后在push到云端

大概的理解为
[工作区 Working Directory]					# 本地文件
    ↓ git add
[暂存区 Staging Area]						# Staging Area
    ↓ git commit
[本地仓库 Local Repository，含分支 main]	# 本地仓库，标注了一些本地以及远端仓库的信息的东西，和本地文件Workspace不一样
    ↓ git push
[远端仓库 Remote Repository，origin/main]	# Cloud上的仓库， 别名为origin/main

- git diff --staged 的作用?
 -- git diff：对比 工作区 和 暂存区 的差异。
 -- git diff --staged（或 --cached）：对比 暂存区 和 最后一次 commit 的差异。
 
🍴 Fork
	把别人仓库完整复制到你自己的 GitHub 账户下。
	Fork 后你就拥有了一个独立的副本，可以随意改代码。
	常见用途：
		想自己基于这个项目做二次开发。
		想给原项目贡献代码（通常流程是 Fork → 修改 → 提交 Pull Request）。
存在的理由：一般是团队的成员每个人需要有自己的版本，即使用Fork. 表示说，我在我自己的独立副本中进行开发

🔹 Branch（分支）
	作用：在同一个仓库里分隔不同的开发线。
	典型用法：
		main / master 分支 → 稳定版本
		feature/... 分支 → 新功能开发
		bugfix/... 分支 → 修 bug
	特点：
		所有分支都在同一个仓库里。
		方便团队成员一起协作，随时切换、合并。
		需要有仓库的 写权限 才能直接创建分支。

🔹 Fork（派生）
	作用：在自己的 GitHub 账号下复制一份完整仓库。
	典型用法：
		没有原仓库写权限的人（比如开源项目贡献者），Fork 一份到自己账号里，改动之后再发 PR 回去。
	特点：
		Fork 出来的是一个完全独立的仓库，你就是它的拥有者。
		你可以随意创建分支，不会影响原仓库。
		常用于 开源社区，而不是小团队内部。

🔄 对比总结
	Branch → 一个仓库内部的多条“开发线”，团队内部常用。
	Fork → 一个仓库的完整副本，常用于没有权限的开发者对开源项目贡献代码。

2. command lines:

- git add files 					# add files into Staging area
- git commit files 					# commit files
- git diff 							# find the files diff of workspace and current used main / branch
- git diff --staged file 			# put the file into staging area
- git status 						# check the status of current workspace
- git restore 						# restore the files from staging area or local changes from used main / branch
- git push							# push all changes into remote main, means cloud main (origin/main)
									  Git 会用 当前分支 和它的 默认远端追踪分支（通常是 origin/main）来推送。
									  这个默认关系是通过 git branch --set-upstream-to=origin/main 建立的。

- git switch main						# switch to branch / main
- git checkout main						# change to main respository
- git switch -c branch_20250825 main 	# create a branch with name "branch_20250825"
- git pull origin main					# make sure the main is updated
- git merge branch_20250825				# merge branch_20250825 into local main repository (precondition, you must be in main 
										  and make sure main is updated)
- git push origin main					# push local main changes into origin/main, means the changes from branch_20250825 
										  will be published into cloud main.
										  git push <remote> <branch> 
											origin → 远端仓库的名字（默认是你 clone 下来时自动设置的）
											main → 本地要推送的分支名字
											👉 含义：把 本地 main 分支 推送到 远端 origin 的 main 分支。
											
3. create an local Git Project and linked to exist Git remote repository
	mkdir Angular_learning
	cd Angular_learning
	echo "# Angular_learning" >> README.md
	git init
	git add README.md
	git commit -m "first commit"
	git branch -M main
	git remote add origin https://github.com/robinqianwu/Angular_learning.git
	git push -u origin main

4. checkout an Git repository into local
	mkdir localFolder
	git clone https://github.com/robinqianwu/Angular_learning localFolder

5. Git 覆盖本地修改常用命令速查表
🔹 放弃工作区未暂存的修改（还没 git add）
	git checkout -- <文件名>
	git checkout -- .
👉 回到最近一次提交的状态。

🔹 放弃暂存区的修改（已 git add，但未 commit）
	git reset HEAD <文件名>
	git checkout -- <文件名>
👉 先把文件移出暂存区，再丢弃修改。

	放弃所有：
	git reset HEAD .
	git checkout -- .

🔹 丢弃本地所有修改和提交，强制和远程同步
	git fetch --all
	git reset --hard origin/<分支名>
👉 本地会直接回到远程分支的最新状态，危险操作（不可恢复）。

🔹 想更新远程代码，但保留本地修改
	git stash
	git pull
	git stash pop
👉 修改会临时保存，拉取远程更新后再恢复。

🔹 回到指定提交（历史版本）
	git reset --hard <commit-id>
👉 完全回到某个历史提交（本地提交会丢失）。

📌 小技巧：
不确定要不要丢弃修改时，可以先查看：
git status

丢弃前想保存一份，以免后悔，可以：
git stash
