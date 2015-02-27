using UnityEngine;
using System.Collections;

public class EnemyPrefControl : MonoBehaviour 
{
	#region Spinball
		//레벨별 출현수량.
		public int spinBallMaxCount01;
		public int spinBallMaxCount02;
		public int spinBallMaxCount03;
		public int spinBallMaxCount04;
		public int spinBallMaxCount05;
		public int spinBallMaxCount06;
		public int spinBallMaxCount07;

		//레벨별 HP.
		public int spinBallHp01;
		public int spinBallHp02;
		public int spinBallHp03;
		public int spinBallHp04;
		public int spinBallHp05;
		public int spinBallHp06;
		public int spinBallHp07;

		//레벨별 속도.
		public int spinBallSpeed01;
		public int spinBallSpeed02;
		public int spinBallSpeed03;
		public int spinBallSpeed04;
		public int spinBallSpeed05;
		public int spinBallSpeed06;
		public int spinBallSpeed07;
				
		//레벨별 등장확률.
		public int spinBallChance01;
		public int spinBallChance02;
		public int spinBallChance03;
		public int spinBallChance04;
		public int spinBallChance05;
		public int spinBallChance06;
		public int spinBallChance07;
	#endregion

	#region Dart
		//레벨별 출현수량.
		public int dartMaxCount01;
		public int dartMaxCount02;
		public int dartMaxCount03;
		public int dartMaxCount04;
		public int dartMaxCount05;
		public int dartMaxCount06;
		public int dartMaxCount07;
		
		//레벨별 HP.
		public int dartHp01;
		public int dartHp02;
		public int dartHp03;
		public int dartHp04;
		public int dartHp05;
		public int dartHp06;
		public int dartHp07;
		
		//레벨별 속도.
		public int dartSpeed01;
		public int dartSpeed02;
		public int dartSpeed03;
		public int dartSpeed04;
		public int dartSpeed05;
		public int dartSpeed06;
		public int dartSpeed07;
		
		//레벨별 등장확률.
		public int dartChance01;
		public int dartChance02;
		public int dartChance03;
		public int dartChance04;
		public int dartChance05;
		public int dartChance06;
		public int dartChance07;
	#endregion

	#region Dust
		//레벨별 출현수량.
		public int dustMaxCount01;
		public int dustMaxCount02;
		public int dustMaxCount03;
		public int dustMaxCount04;
		public int dustMaxCount05;
		public int dustMaxCount06;
		public int dustMaxCount07;
		
		//레벨별 HP.
		public int dustHp01;
		public int dustHp02;
		public int dustHp03;
		public int dustHp04;
		public int dustHp05;
		public int dustHp06;
		public int dustHp07;
		
		//레벨별 속도.
		public int dustSpeed01;
		public int dustSpeed02;
		public int dustSpeed03;
		public int dustSpeed04;
		public int dustSpeed05;
		public int dustSpeed06;
		public int dustSpeed07;
		
		//레벨별 등장확률.
		public int dustChance01;
		public int dustChance02;
		public int dustChance03;
		public int dustChance04;
		public int dustChance05;
		public int dustChance06;
		public int dustChance07;
	#endregion

	#region Shield
		//레벨별 출현수량.
		public int shieldMaxCount01;
		public int shieldmaxCount02;
		public int shieldMaxCount03;
		public int shieldMaxCount04;
		public int shieldMaxCount05;
		public int shieldMaxCount06;
		public int shieldMaxCount07;
		
		//레벨별 HP.
		public int shieldHp01;
		public int shieldHp02;
		public int shieldHp03;
		public int shieldHp04;
		public int shieldHp05;
		public int shieldHp06;
		public int shieldHp07;
		
		//레벨별 속도.
		public int shieldSpeed01;
		public int shieldSpeed02;
		public int shieldSpeed03;
		public int shieldSpeed04;
		public int shieldSpeed05;
		public int shieldSpeed06;
		public int shieldSpeed07;
		
		//레벨별 등장확률.
		public int shieldChance01;
		public int shieldChance02;
		public int shieldChance03;
		public int shieldChance04;
		public int shieldChance05;
		public int shieldChance06;
		public int shieldChance07;
	#endregion

	#region Portal
		//포탈 생성 간격.
		public int portalNextInterval = 20;
		//포탈 단계 유지시간.
		public int portalLevelStayTime01 = 45;
		public int portalLevelStayTime02 = 95;
		public int portalLevelStayTime03 = 150;
		public int portalLevelStayTime04 = 210;
		public int portalLevelStayTime05 = 275;
		public int portalLevelStayTime06 = 345;
		public int portalLevelStayTime07 = 100000;
	#endregion
}
