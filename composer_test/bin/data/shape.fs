uniform float time;
uniform vec2 resolution;
uniform vec2 mouse;
uniform float uni_n;//0<10
uniform float uni_p;//0<600	
uniform float uni_freq;//0<10
uniform float uni_off;//-10<10
uniform sampler2DRect backbuffer; // Previus frame for PingPong

uniform sampler2DRect tex0; // First dot on the left of the patch
uniform sampler2DRect tex1; // Second dot on the left of the patch

const float pi = 3.1415926;

void main(void){
 vec2 p = uni_off+ 2.0 * gl_FragCoord.xy / resolution.xy;
 p.y *= resolution.y/resolution.x;
 p *= uni_p;
 float tot = pi*2.0;
 float n = uni_n;
 float df = tot/n;
 float c = 0.0;
 float t = time*uni_freq;

 for (float phi =0.0; phi < tot; phi+=df){
 c+=cos(cos(phi)*p.x+sin(phi)*p.y +t);
 }

  
 vec2 st = gl_FragCoord.xy;

 //vec4 A = texture2DRect(tex0, st);
vec4 A = vec4(1.0,1.0,1.0,1.0);
 //vec4 B = texture2DRect(tex1, st);
 vec4 B = vec4(0.0,0.0,0.0,1.0);

 gl_FragColor = mix(A,B,c);
}