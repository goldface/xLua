![](Assets/XLua/Doc/xLua.png)

[![license](http://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/Tencent/xLua/blob/master/LICENSE.TXT)
[![release](https://img.shields.io/badge/release-v2.1.14-blue.svg)](https://github.com/Tencent/xLua/releases)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-blue.svg)](https://github.com/Tencent/xLua/pulls)
[![Build status](https://travis-ci.org/Tencent/xLua.svg?branch=master)](https://travis-ci.org/Tencent/xLua)

## C#을 위한 Lua프로그래밍 솔루션

xLua는 Unity, .Net, Mono 및 기타 C#환경에 Lua스크립팅 기능을 추가합니다. xLua를 통해 Lua코드와 C# 코드는 서로 쉽게 호출 할 수 있습니다.

## xLua의 뛰어난 기능

xLua는 기능, 성능 및 사용 편의성에 있어서 많은 혁신을 가지고 있습니다. 가장 중요한 기능은 다음과 같습니다:

* 런타임 동안 Lua에서 C# 구현 (메소드, 연산자, 속성, 이벤트 등)을 대체 할 수 있습니다.
* 뛰어난 GC최적화, 사용자 정의 구조체, C#과 Lua사이에 열거 된 객체를 전달 할 때 C# GC할당이 없음;
* 편집기 모드에서 코드를 생성 할 필요가 없는 경량 개발;

## 설치

Zip패키지의 압축을 풀면 Unity프로젝트의 Assets디렉토리에 해당하는 Assets디렉토리가 표시됩니다. Unity프로젝트에서 디렉토리 구조를 유지하십시오.

다른 디렉토리에 설치하려면 [FAQs](Assets/XLua/Doc/Faq_EN.md)를 참조하십시오.

## 문서들

* [FAQs](Assets/XLua/Doc/Faq_EN.md): 자주 묻는 질문이 여기에 요약되어 있습니다. 초보자를 위한 질문에 대한 답변을 찾을 수 있습니다.
* (필독) [XLua 튜토리얼](Assets/XLua/Doc/XLua_Tutorial_EN.md): 튜토리얼입니다. 지원 코드는 여 [여기](Assets/XLua/Tutorial/)에서 찾을 수 있습니다.
* (필독) [XLua 구성](Assets/XLua/Doc/Configure_EN.md): xLua를 구성 하는 방법에 대한 설명.
* [핫픽스 사용 설명서](Assets/XLua/Doc/Hotfix_EN.md): 핫픽스 기능을 사용하는 방법에 대한 설명.
* [xLua에서 타사 Lua라이브러리 추가/제거](Assets/XLua/Doc/Add_Remove_Lua_Lib.md): 타사 Lua확장 라이브러리를 추가하거나 제거하는 방법에 대한 설명.
* [xLua APIs](Assets/XLua/Doc/XLua_API_EN.md): API 문서
* [빌드 엔진 보조 개발 가이드](Assets/XLua/Doc/Custom_Generate_EN.md): 빌드 엔진 보조 개발을 사용하는 방법에 대한 설명

## 빠른 시작

3줄의 코드면 끝입니다.

xLua를 설치하고 MonoBehaviour를 시나리오에 드래그하고, 다음의 코드를 추가하세요:

```csharp
XLua.LuaEnv luaenv = new XLua.LuaEnv();
luaenv.DoString("CS.UnityEngine.Debug.Log('hello world')");
luaenv.Dispose();
```

1. DoString 매개 변수는 문자열이며, 허용 가능한 Lua코드를 입력 할 수 있습니다. 이 예제에서 Lua는 C#의 UnityEngine.Debug.Log를 호출하여 로그를 출력합니다.

2. LuaEnv인스턴스는 Lua가상 머신에 해당합니다. 오버헤드 때문에, Lua가상 머신은 전체적으로 고유한 것을 권장합니다.

C#이 Lua를 호출하는 것은 간단합니다. 예를 들면, Lua의 시스템 함수를 호출하기 위해 권장되는 방법은 다음과 같습니다:

* 정의

```csharp
[XLua.CSharpCallLua]
public delegate double LuaMax(double a, double b);
```

* 바인드

```csharp
var max = luaenv.Global.GetInPath<LuaMax>("math.max");
```

* 호출

```csharp
Debug.Log("max:" + max(32, 12));
```

한 번 바인드하고 재사용하는 것을 권장합니다. 코드가 생성되면, max를 호출할 때 GC Alloc이 생성되지 않습니다.

## 핫픽스

* 이것은 침입성이 낮으며, 이전 프로젝트의 원래 코드를 수정하지 않고도 사용할 수 있습니다.
* 이것은 런타임에 거의 영향을 미치지 않으며, 핫픽스를 사용하지 않는 원래 프로그램과 거의 동일합니다.
* 문제가 있는 경우 Lua를 사용하여 패치 할 수 있습니다. 그러면 Lua코드 로직이 관여합니다.

사용 방법 안내는 [여기](Assets/XLua/Doc/Hotfix_EN.md)에 있습니다.

## 더 많은 예제

* [01_Helloworld](Assets/XLua/Examples/01_Helloworld/): 빠른 시작 예제
* [02_U3DScripting](Assets/XLua/Examples/02_U3DScripting/): 이 예제는 Mono를 사용하여 MonoBehaviour를 작성하는 방법을 보여줍니다.
* [03_UIEvent](Assets/XLua/Examples/03_UIEvent/): 이 예제는 Lua를 사용하여 UI로직을 작성하는 방법을 보여줍니다.
* [04_LuaObjectOrented](Assets/XLua/Examples/04_LuaObjectOrented/): 이 예제는 Lua의 객체 지향 프로그래밍과 C#간의 협력을 보여줍니다.
* [05_NoGc](Assets/XLua/Examples/05_NoGc/): 이 예제는 값 유형의 GC를 피하는 방법을 보여줍니다.
* [06_Coroutine](Assets/XLua/Examples/06_Coroutine/): 이 예제는 Lua코루틴이 Unity코루틴과 작동하는 방식을 보여줍니다.
* [07_AsyncTest](Assets/XLua/Examples/07_AsyncTest/): 이 예제는 Lua코루틴을 사용하여 비동기 로직을 동기화하는 방법을 보여줍니다.
* [08_Hotfix](Assets/XLua/Examples/08_Hotfix/): 핫픽스 예제입니다.(핫픽스 기능을 활성화하십시오. 자세한 내용은 [가이드](Assets/XLua/Doc/Hotfix_EN.md)를 참조하십시오.))
* [09_GenericMethod](Assets/XLua/Examples/09_GenericMethod/): 이 예제는 제네릭 메서드에 대한 데모입니다.
* [10_SignatureLoader](Assets/XLua/Examples/10_SignatureLoader/): 이 예제는 디지털 서명으로 Lua스크립트를 읽는 방법을 보여줍니다. 자세한 내용은 [디지털 서명](Assets/XLua/Doc/signature.md) 문서를 참조하십시오.
* [11_RawObject](Assets/XLua/Examples/11_RawObject/): 이 예제는 C# 매개변수가 object일 때, 어떻게 하나의 Lua Number 지정이 boxing된 int로 전달되는지를 보여줍니다.
* [12_ReImplementInLua](Assets/XLua/Examples/12_ReImplementInLua/): 복잡한 값 유형을 Lua구현으로 변경하는 방법을 보여줍니다.

## 기술지원

QQ Group 1: 612705778 (가득 찼을 수 있음)

QQ Group 2: 703073338

문제 확인: 문제가 발생하면 FAQs를 먼저 읽어보십시오.

