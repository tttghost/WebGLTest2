#!/bin/bash

# GitHub CLI가 설치되어 있는지 확인
if ! command -v gh &> /dev/null; then
    echo "❌ GitHub CLI(gh)가 설치되어 있지 않습니다. 설치 후 다시 실행하세요."
    exit 1
fi

echo "🔹 Pull Request 생성 시작..."

# PR을 올릴 브랜치 선택 (기본값: 현재 브랜치)
read -p "PR을 올릴 브랜치 이름을 입력하세요 (기본: 현재 브랜치): " HEAD_BRANCH
HEAD_BRANCH=${HEAD_BRANCH:-$(git branch --show-current)}

# PR의 기준 브랜치 입력 (예: main, develop)
read -p "PR의 기준(base) 브랜치를 입력하세요 (기본: main): " BASE_BRANCH
BASE_BRANCH=${BASE_BRANCH:-main}

# PR 제목과 본문 입력 받기
read -p "PR 제목을 입력하세요: " PR_TITLE
read -p "PR 본문을 입력하세요: " PR_BODY

# 리뷰어 지정 (쉼표로 구분)
REVIEWERS="user1,user2,user3"  # GitHub 사용자명 입력
ASSIGNEE="@me"  # 본인을 Assignee로 설정 (필요 없으면 삭제 가능)

# 레이블과 마일스톤 지정 (필요하면 설정)
LABELS="bug,enhancement"
MILESTONE="v1.0"

# PR 생성 명령 실행
gh pr create \
    --base "$BASE_BRANCH" \
    --head "$HEAD_BRANCH" \
    --title "$PR_TITLE" \
    --body "$PR_BODY" \
    --reviewer "$REVIEWERS" \
    --assignee "$ASSIGNEE" \
    --label "$LABELS" \
    --milestone "$MILESTONE"

# 실행 결과 확인
if [ $? -eq 0 ]; then
    echo "✅ Pull Request가 성공적으로 생성되었습니다."
else
    echo "❌ PR 생성에 실패했습니다."
fi
