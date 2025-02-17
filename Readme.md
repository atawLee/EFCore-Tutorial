# 생산성을 위한 EF Core 활용

*ORM의 사용이 쿼리를 몰라도 된다는 것은 아닙니다. 단 SQL작업을 줄이는 일에 대해서 설명합니다.*

"Writing an ORM is ... complex
Being aware of what happens under the hood is always important
Check the SQL being generated"

## Code First
스키마의 정의를 EF Core를 이용해서 C#으로 진행하는 것을 설명합니다. 
https://blog.atawlee.com/25


## 구조
```
src
├─Application
├─Database
│  ├─Context
│  └─Entity
├─Migrator
│  └─Migrations
└─Repository
```
## 각 프로젝트별 역할
Application : 테스트를 위한 콘솔 어플리케이션 실행 프로젝트
Database : EF Core의 DbContext와 엔터티 정의 프로젝트
Migrator : 마이그레이션을 관리하는 프로젝트
Repository : DbContext를 이용해서 데이터를 가져오는 프로젝트 



