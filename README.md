# 实时翻译AI Agent
## 项目描述

## 项目PRD
### 需求背景

### 需求描述

### 模型工作流
模型调用工作流
![image](https://github.com/user-attachments/assets/f5001ab2-c3b7-4123-81d5-e8c04e1a6055)

### 模型参数
#### 节点一
**模型**：GPT4o-mini-transribe
**参数**：
temperature: 0.3
max_tokens: 1000
top_p: 1.0
frequency_penalty: 0.0

### System Prompt



### User Prompt


#### 节点二
**模型**：GPT4o-mini
**参数**：
temperature: 0.3
max_tokens: 1000
top_p: 1.0
frequency_penalty: 0.0

* System Prompt



### User Prompt
{tts结果}

## 技术实现
后端架构设计
![image](https://github.com/user-attachments/assets/b2c10d69-17ea-4de2-9376-af587598a71e)
