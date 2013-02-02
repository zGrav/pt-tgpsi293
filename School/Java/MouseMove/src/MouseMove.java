import java.awt.MouseInfo;
public class MouseMove {

	/**
	 * @param args
	 */
	public static void main(String[] args)throws InterruptedException {
		// TODO Auto-generated method stub
			while(true){
				Thread.sleep(100);
				System.out.println("("+MouseInfo.getPointerInfo().getLocation().x+", "+MouseInfo.getPointerInfo().getLocation().y+")");
			}
		}
	}
