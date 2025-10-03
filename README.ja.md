# Music Local UI

- [Read in Russian](README.ru.md)
- [Read in English](README.md)

![ui](https://github.com/user-attachments/assets/6aa030e0-b3b0-4f1d-99df-3f6403cb037d)

ローカルオーディオファイル用の軽量Windows音楽プレーヤー（1MB未満のサイズ）。

## 機能
- **コンパクトサイズ**: 合計約1MBのみ
- **フォーマットサポート**: MP3, WAV, FLAC, AAC, OGG, WMA, M4A
- **トラック情報**:
  - 再生時間表示 (hh:mm:ss)
  - ビットレート
  - ファイル拡張子
  - ファイルサイズ
  - 作成日
- **再生コントロール**:
  - 再生/一時停止 ▶️ ボタン
  - 次のトラック 'Next' ボタン
  - 前のトラック 'Previous' ボタン
- **多言語対応**: ロシア語/英語サポート - 近日対応

## システム要件
- **OS**: Windows 7 以降
- **.NET Framework**: 4.7.2
- **ディスク空き容量**: 2MB 未満

## インストール
1. 最新リリースをダウンロード
2. ZIPファイルを解凍
3. `MusicLocalUI.exe` を実行

### 同梱ファイル:
- `MusicLocalUI.exe` (メインアプリケーション)
- `TagLibSharp.dll` (メタデータライブラリ)

## 使用方法
1. 「Open」をクリックして音楽フォルダを選択
2. 「Scan」をクリックしてトラックを読み込み
3. 再生コントロール:
   - ▶️ 現在のトラックを再生/一時停止
   - 次のトラックには 'Next' ボタン
   - 前のトラックには 'Previous' ボタン
4. 「Track info」セクションでトラック詳細を表示

## 追加機能
- 全トラックの合計再生時間計算
- 再生モード: 順番/ランダム/リピート
- 言語切替 (RU/EN) - 近日対応
- フォルダスキャン状況の表示

## トラブルシューティング
アプリケーションが起動しない場合:
1. [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472) をインストール
2. 両ファイルが同じフォルダにあることを確認
3. 必要に応じて管理者権限で実行

## ライセンス
このプロジェクトはMITライセンスの下でライセンスされています - 詳細は[LICENSE](LICENSE)ファイルを参照してください。